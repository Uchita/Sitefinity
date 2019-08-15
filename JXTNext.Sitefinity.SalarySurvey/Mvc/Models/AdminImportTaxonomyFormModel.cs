using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using JXTNext.Sitefinity.SalarySurvey.Helpers;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Models
{
    public class AdminImportTaxonomyFormModel
    {
        [Required(ErrorMessage = FormHelper.RequiredFieldMessage)]
        public HttpPostedFileBase file { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = FormHelper.RequiredFieldMessage)]
        public string Taxonomy { get; set; }

        public string SalarySurveyAction { get; set; }
    }
}
