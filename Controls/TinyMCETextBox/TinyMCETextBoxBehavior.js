// README
//
// There are two steps to adding a property:
//
// 1. Create a member variable to store your property
// 2. Add the get_ and set_ accessors for your property
//
// Remember that both are case sensitive!


/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />


Type.registerNamespace('TinyMCETextBox');

TinyMCETextBox.TinyMCETextBoxBehavior = function(element) {
    TinyMCETextBox.TinyMCETextBoxBehavior.initializeBase(this, [element]);

    this._postBackPending = null;
    this._pageLoadingHandler = null;
    this._initOpts = null;
}
TinyMCETextBox.TinyMCETextBoxBehavior.prototype = {
    initialize : function() {
        TinyMCETextBox.TinyMCETextBoxBehavior.callBaseMethod(this, 'initialize');

		this.registerPartialUpdateEvents();
		this._pageLoadingHandler = Function.createDelegate(this, this._pageLoading);
		this._pageRequestManager.add_pageLoading(this._pageLoadingHandler);

		var element = this.get_element();
		if (tinyMCE.getInstanceById(element.id) == null || tinyMCE.getInstanceById(element.id) == "undefined")
		{
			eval("tinyMCE.init({"+this._initOpts+"})");
			tinyMCE.execCommand('mceAddControl',false, element.id);
		}
    },

    dispose : function() {
        if (this._pageRequestManager && this._pageLoadingHandler) {
            this._pageRequestManager.remove_pageLoading(this._pageLoadingHandler);
            this._pageLoadingHandler = null;
        }
        TinyMCETextBox.TinyMCETextBoxBehavior.callBaseMethod(this, 'dispose');
    },
	_partialUpdateBeginRequest : function(sender, beginRequestEventArgs) {
        TinyMCETextBox.TinyMCETextBoxBehavior.callBaseMethod(this, '_partialUpdateBeginRequest', [sender, beginRequestEventArgs]);
        if (!this._postBackPending) {
				//tinyMCE.getInstanceById(this.get_element().id).setProgressState(1); 
            this._postBackPending = true;
        }
    },
    _pageLoading : function(sender, args) {
        if (this._postBackPending) {
            this._postBackPending = false;
            
            var element = this.get_element();
				var panels = args.get_panelsUpdating();
				for (var i = 0; i < panels.length; i++) {
					var el=element;
					while(el!=null)
					{
						if(el==panels[i]) break;
						el = el.parentNode;
					}
					if(el!=null)
					{
						if (tinyMCE.getInstanceById(element.id) != null && tinyMCE.getInstanceById(element.id) != "undefined")
						{
						 //tinyMCE.getInstanceById(this.get_element().id).setProgressState(0); 
						 tinyMCE.execCommand('mceFocus', false, element.id);   
						 tinyMCE.execCommand('mceRemoveControl',false,element.id);
						}
						break;
					}
				}
        }
	},
	get_InitOpts : function() {
        /// <value type="String">
        /// The script to invoke instead of calling a Web or Page method. This script must evaluate to a string value.
        /// </value>
        return this._initOpts;
    },   
    set_InitOpts : function(value) {
        if (this._initOpts != value) {
            this._initOpts = value;
            this.raisePropertyChanged('InitOpts');
        }
    }
}
TinyMCETextBox.TinyMCETextBoxBehavior.registerClass('TinyMCETextBox.TinyMCETextBoxBehavior', AjaxControlToolkit.BehaviorBase);
