
var dropDownOptions = {
    title : "Dropdown",
    data : [],
    closedArrow : '<i class="fa fa-caret-right" aria-hidden="true"></i>',
    openedArrow : '<i class="fa fa-caret-down" aria-hidden="true"></i>',
    maxHeight : 300,
    multiSelect : false,
    selectChildren : false,
    addChildren: false,
    clickHandler : function(target){},
    expandHandler : function(target,expanded){},
    checkHandler : function(target,checked){},
	expandChildren: false,
    rtl: false,
};

var globalTreeIdCounter=0;

(function($) {

    //data inits from options
    $.fn.DropDownTree = function(options){
    //helpers
    function RenderData(data, element){		
        for(var i = 0 ; i< data.length ; i++){
            globalTreeIdCounter++;
            var dataAttrs = " data-title='" + data[i].Label.toUpperCase() + "'";
            if(typeof data[i].dataAttrs != "undefined" && data[i].dataAttrs != null){
                for(var d = 0 ; d<data[i].dataAttrs.length ; d++){
                    dataAttrs += " data-" + data[i].dataAttrs[d].Label + "='" + data[i].dataAttrs[d].Filters+"' ";
                }
            }
            if(!element.is("li")){
                element.append('<li id=' + data[i].ID + dataAttrs + '>' + (options.multiSelect ? '<i class="fa fa-square-o select-box" aria-hidden="true"></i>' : '') + '<a href="' + ((typeof data[i].href != "undefined" && data[i].href != null) ? data[i].href : '#') + '">' + data[i].Label+'</a></li>');
                if (data[i].Filters != null && typeof data[i].Filters != "undefined" && data[i].Filters.length > 0){					
                    $("#" + data[i].ID).append("<ul style='display:none'></ul>");
                    $("#" + data[i].ID).find("a").first().prepend('<span class="arrow">'+options.closedArrow+'</span>');
                    RenderData(data[i].Filters, $("#" + data[i].ID).find("ul").first());
                 }else if(options.addChildren){
                    $("#" + data[i].ID).find("a").first().prepend('<span class="arrow">'+options.closedArrow+'</span>');
                }
            }
            else{
                element.find("ul").append('<li id=' + data[i].ID + dataAttrs + '>' + (options.multiSelect ? '<i class="fa fa-square-o select-box" aria-hidden="true"></i>' : '') + '<a href="' + ((typeof data[i].href != "undefined" && data[i].href != null) ? data[i].href : '#') + '">' + data[i].Label+'</a></li>');
                if (data[i].Filters != null && typeof data[i].Filters !="undefined"){					
                    $("#" + data[i].ID).append("<ul style='display:none'></ul>");
                    $("#" + data[i].ID).find("a").first().prepend('<span class="arrow">'+options.closedArrow+'</span>');
                    RenderData(data[i].Filters, $("#" + data[i].ID).find("ul").first());
                }else if(options.addChildren){
                    $("#" + data[i].ID).find("a").first().prepend('<span class="arrow">'+options.closedArrow+'</span>');
                }
            }
        }
		
		if(options.expandChildren == true ){
			$(options.element).children("ul").find("ul").css('display','block');
			$(options.element).children("ul").find('span').children('i').removeClass('fa-caret-right');
			$(options.element).children("ul").find('span').children('i').addClass('fa-caret-down');
		}
    }

    options = $.extend({}, dropDownOptions, options, {element:this});


    //protos inits
    $(options.element).init.prototype.clickedElement = null;

	var tree = $(options.element);

    //handlers binders
    //element click handler
    $(options.element).on("click","li",function(e){
    	tree.init.prototype.clickedElement = $(this);
    	options.clickHandler(tree.clickedElement, e);
        e.stopPropagation();
    });
	
	$(options.element).on("keyup","input",function(o){
       	
        var text = $(this).val().toUpperCase();
        $(options.element).find("li").css("display", "block");
        $($(options.element).find("li")).each(function (i, el) {
            if (text != '' && $(el).attr("data-title").startsWith(text)) {
               $(el).addClass("filtered");
            }
            else if (text != '') {
                $(el).removeClass("filtered");
                $(el).css("display", "none");
            }
        });
        $($(options.element).find("li").filter(".filtered")).each(function (i, t) {
            $(t).parents("li").css("display", "block");
        });
		
        if ($(this).val().length > 0) {
            $(options.element).children("ul").find("ul").css('display', 'block');
            $(options.element).children("ul").find('span').children('i').removeClass('fa-caret-right');
            $(options.element).children("ul").find('span').children('i').addClass('fa-caret-down');
        }
    });
	
	function filterOptions(data,text)
	{	
		
		if(text == '' || text == undefined)
			return data;
		text = text.toUpperCase();
		var filteredOptions = [];		
		for(var i = 0; i < data.length; i++)
		{			
            if (data[i].Filters != undefined && data[i].Filters.length > 0)
			{
                data[i].Filters = filterOptions(data[i].Filters,text);
			}
            if ((data[i].Filters != undefined && data[i].Filters.length > 0) || data[i].Label.toUpperCase().startsWith(text))
					filteredOptions.push(data[i]);
		}
		return filteredOptions;
	};

    //arrow click handler close/open
    $(options.element).on("click",".arrow",function(e){
        e.stopPropagation();
        $(this).empty();
        var expanded;
        if($(this).parents("li").first().find("ul").first().is(":visible")){
            expanded = false;
            $(this).prepend(options.closedArrow);
            $(this).parents("li").first().find("ul").first().hide();
        }else{
            expanded = true;
            $(this).prepend(options.openedArrow);
            $(this).parents("li").first().find("ul").first().show();
        }
        options.expandHandler($(this).parents("li").first(), e, expanded);
    });


    //select box click handler
    $(options.element).on("click",".select-box",function(e){
        e.stopPropagation();
        var checked;
        if($(this).hasClass("fa-square-o")){
            //will select
            checked=true;
            $(this).removeClass("fa-square-o");
            $(this).addClass("fa-check-square-o");
            if(options.selectChildren){
                $(this).parents("li").first().find(".select-box").removeClass("fa-square-o");
                $(this).parents("li").first().find(".select-box").addClass("fa-check-square-o");
            }
        }else{
            //will unselect
            checked=false;
            $(this).addClass("fa-square-o");
            $(this).removeClass("fa-check-square-o");
            if(options.selectChildren){
                $(this).parents("li").first().find(".select-box").addClass("fa-square-o");
                $(this).parents("li").first().find(".select-box").removeClass("fa-check-square-o");
            }
        }
        var selectedElementText = $(options.element).GetSelectedElementsText();
        var titleText = options.title;
        if (selectedElementText.length > 3) {
            titleText = selectedElementText.length + " selected";
        }
        else if (selectedElementText.length > 0) {
            titleText = selectedElementText.join(' & ');
        }
        $(options.element).SetTitle(titleText);
        options.checkHandler($(this).parents("li").first(), e, checked);
    });

    if(options.rtl){
        $(options.element).addClass("rtl-dropdown-tree");
        if(options.closedArrow.indexOf("fa-caret-right")>-1){
            options.closedArrow = options.closedArrow.replace("fa-caret-right","fa-caret-left");
        } 
    }	
    $(options.element).append('<button class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true"><span class="dropdowntree-name">'+options.title+'</span><span class="caret"></span></button>');		
    $(options.element).append('<ul style="max-height: '+options.maxHeight+'px" class="dropdown-menu" aria-labelledby="dropdownMenu1"><input type="text" class="form-control" placeholder="Type here to filter..." /></ul>');

    RenderData(options.data,$(options.element).find("ul").first());
	

    //protos inits
    $(options.element).init.prototype.GetParents = function(){
        var jqueryClickedElement = $(options.element).clickedElement;
        return $(jqueryClickedElement).parents("li");
    };
	

    $(options.element).init.prototype.SetTitle = function(title){
        $(this).find(".dropdowntree-name").text(title);
    };

    $(options.element).init.prototype.GetSelected = function(title){
        var selectedElements = [];
        $(this).find(".fa-check-square-o").each(function(){
            selectedElements.push($(this).parents("li").first());
        });
        return selectedElements;
        };

    $(options.element).init.prototype.GetSelectedElementIds = function(title){
        var selectedElementIds = [];
        $.each($(this).GetSelected(), function (i, element) {
            selectedElementIds.push($(element).attr("id"));
        });
        return selectedElementIds;
    };

    $(options.element).init.prototype.GetSelectedElementsText = function (title) {
        var selectedElementText = [];
        $.each($(this).GetSelected(), function (i, element) {
            selectedElementText.push($(element).children('a').text());
        });
        return selectedElementText;
    };

    $(options.element).init.prototype.AddChildren = function(element, arrOfElements){
        if(options.addChildren && $(element).find("ul").length == 0)
            $(element).append("<ul></ul>");
        element = $(element).find("ul").first();
        if(element.find("li").length==0)
            RenderData(arrOfElements, element);
    };

};
})(jQuery);