/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.filebrowserBrowseUrl = "http://www.fmplus.com.au/Admin/FileBrowser.aspx";
    config.filebrowserImageBrowseUrl = "http://www.fmplus.com.au/Admin/FileBrowser.aspx?type=Image";
    config.filebrowserImageBrowseLinkUrl = "http://www.fmplus.com.au/Admin/FileBrowser.aspx";
    config.filebrowserWindowHeight = "620";
    config.filebrowserWindowWidth = "1030";
    config.allowedContent = true;
};
