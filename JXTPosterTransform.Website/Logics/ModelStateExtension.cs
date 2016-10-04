using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXTPosterTransform.Website.Logics
{
    public static class ModelStateExtension
    {
        public static bool HasModelStateError(this ModelStateDictionary modelState, string targetKey)
        {
            if (modelState.ContainsKey(targetKey) && modelState[targetKey] != null)
            {
                return modelState[targetKey].Errors.Any();
            }
            return false;
        }
    }
}