#region Assembly Telerik.Sitefinity.Frontend, Version=11.0.6726.0, Culture=neutral, PublicKeyToken=b28c218413bdf563
// C:\Developments\JXTNext\Sitefinity\packages\Telerik.Sitefinity.Feather.Core.11.0.6726\lib\net471\Telerik.Sitefinity.Frontend.dll
#endregion

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models
{
    //
    // Summary:
    //     The rendering options for a widget.
    //
    // Remarks:
    //     Each option describes different selection of items that will be included while
    //     rendering a widget.
    public enum SelectionMode
    {
        //
        // Summary:
        //     Refers to all items.
        AllItems = 0,
        //
        // Summary:
        //     Refers to custom selection of items.
        SelectedItems = 1,
        //
        // Summary:
        //     Refers to filtered items based on a custom criteria.
        FilteredItems = 2,

        //
        // Summary:
        //     Refers to filtered items based on a taxonomy
        TaxonomyItems = 3
    }
}