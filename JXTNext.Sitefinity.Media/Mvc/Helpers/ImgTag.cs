using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXTNext.Sitefinity.Media.Mvc.Helpers
{
    public class ImgTag : IHtmlString
    {
        private readonly string _imagePath;
        private readonly Func<string, string> _mapVirtualPath;
        private readonly HashSet<int> _pixelDensities;
        private readonly IDictionary<string, string> _htmlAttributes;

        /// <summary>
        /// The ImgTag HTML helper builds an image tag from 
        /// </summary>
        /// <param name="imagePath">The path to the image.</param>
        /// <param name="altText">The alternative text for the image.</param>
        /// <param name="mapVirtualPath"></param>
        /// <param name="resolveAsAbsoluteUrl">Whether the urls should be absolute.</param>
        public ImgTag(string imagePath, string altText, Func<string, string> mapVirtualPath, bool resolveAsAbsoluteUrl = false)
        {
            _imagePath = imagePath;
            _mapVirtualPath = mapVirtualPath;

            _pixelDensities = new HashSet<int>();
            _htmlAttributes = new Dictionary<string, string>
            {
                { "src", mapVirtualPath(imagePath) },
                { "alt", altText }
            };
        }

        public string ToHtmlString()
        {
            var imgTag = new TagBuilder("img");

            // TODO: Future enhancment add support for responsive images
            //if (_pixelDensities.Any())
            //{
            //    AddSrcsetAttribute(imgTag);
            //}

            foreach (KeyValuePair<string, string> attribute in _htmlAttributes)
            {
                imgTag.Attributes[attribute.Key] = attribute.Value;
            }

            return imgTag.ToString(TagRenderMode.SelfClosing);
        }

        // TODO: Future enhancment add support for responsive images
        //private void AddSrcsetAttribute(TagBuilder imgTag)
        //{
        //    int densityIndex = _imagePath.LastIndexOf('.');

        //    IEnumerable<string> srcsetImagePaths =
        //        from density in _pixelDensities
        //        let densityX = density + "x"
        //        let highResImagePath = _imagePath.Insert(densityIndex, "@" + densityX)
        //            + " " + densityX
        //        select _mapVirtualPath(highResImagePath);

        //    imgTag.Attributes["srcset"] = string.Join(", ", srcsetImagePaths);
        //}

        //public ImgTag WithDensities(params int[] densities)
        //{
        //    foreach (int density in densities)
        //    {
        //        _pixelDensities.Add(density);
        //    }

        //    return this;
        //}

        /// <summary>
        /// Used to add a width and height attribute to the image tag.
        /// </summary>
        /// <param name="width">The width attribute value.</param>
        /// <param name="height">The height attibute value.</param>
        /// <returns></returns>
        public ImgTag WithSize(int width, int? height = null)
        {
            _htmlAttributes["width"] = width.ToString();
            _htmlAttributes["height"] = (height ?? width).ToString();

            return this;
        }

        /// <summary>
        /// Used to add a CSS class to the image tag.
        /// </summary>
        /// <param name="cssClass">The CSS class name/s.</param>
        /// <returns></returns>
        public ImgTag WithCssClass(string  cssClass)
        {
            _htmlAttributes["class"] = cssClass;

            return this;
        }
    }
}
