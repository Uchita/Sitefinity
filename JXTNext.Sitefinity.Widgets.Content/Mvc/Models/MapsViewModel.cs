using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models
{
    public class MapsViewModel
    {
        public List<MapsMarkerModel> MapsMarkers { get; set; }
        public int ZoomLevel { get; set; }
    }

    public class MapsMarkerModel
    {
        public string Address { get; set; }
        public string MarkerIconPath { get; set; }
        public string PopupTitle { get; set; }
        public string PopupText { get; set; }
        public string PopupAdditionalInfo { get; set; }
    }
}
