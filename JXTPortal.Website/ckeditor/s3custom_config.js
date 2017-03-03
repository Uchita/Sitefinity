/**
* @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
* For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here.
    // For the complete reference:
    // http://docs.ckeditor.com/#!/api/CKEDITOR.config

    config.toolbar = 'SmallToolbar';
    config.toolbar_SmallToolbar = [
            ['Source'],
            ['Bold', 'Italic', 'Underline'],
            ['NumberedList', 'BulletedList'],
            ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock']
       ];


    config.toolbar = 'FullToolbar';
    config.extraPlugins = "templates";
    config.toolbar_FullToolbar =
    [
        ['Source', '-', 'Templates'],
        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'SpellChecker', 'Scayt'],
        ['Undo', 'Redo', '-', 'Find', 'Replace'],
        ['Image', 'Link', 'Unlink', 'Anchor'],
        '/',
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
        ['Table', 'HorizontalRule', 'SpecialChar', 'PageBreak'],
         '/',
        ['Styles', 'Format', 'Font', 'FontSize'],
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
        ['Maximize']
    ];


    if (location.href.toLowerCase().indexOf("/admin/") > -1) {
        config.filebrowserBrowseUrl = "/Admin/S3FileBrowser.aspx";
        config.filebrowserImageBrowseUrl = "/Admin/S3FileBrowser.aspx?type=Image";
        config.filebrowserImageBrowseLinkUrl = "/Admin/S3FileBrowser.aspx";
    }
    config.filebrowserWindowHeight = "620";
    config.filebrowserWindowWidth = "1030";
    config.allowedContent = true;
    //config.enterMode = CKEDITOR.ENTER_BR; // inserts <br />
};
