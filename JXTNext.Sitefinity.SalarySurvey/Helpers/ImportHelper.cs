using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System;
using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Helpers
{
    class ImportHelper
    {
        /// <summary>
        /// Method to add an error message in response. Maxmimum errors are 100.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        public static void AddResponseError(GenericAjaxResponseModel response, string error)
        {
            if (response.messages[GenericAjaxResponseModel.Global].Count >= 100)
            {
                throw new Exception("More than 100 errors found. Please review records in the CSV file and try again.");
            }

            response.messages[GenericAjaxResponseModel.Global].Add(error);
        }

        /// <summary>
        /// Method to add an error message in response from an exception.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="row"></param>
        /// <param name="error"></param>
        public static void AddResponseErrorFromException(GenericAjaxResponseModel response, int row, Exception error)
        {
            var rowNum = row > 0 ? ("Row " + row + ": ") : "";

            while (error.InnerException != null)
            {
                error = error.InnerException;
            }

            response.messages[GenericAjaxResponseModel.Global].Add(rowNum + error.Message);
        }

        /// <summary>
        /// Clean a CSV row.
        /// Whitespaces are trimmed and if empty then set to null
        /// </summary>
        /// <param name="record"></param>
        public static void CleanCsvRow(Object record)
        {
            string value;

            foreach (var property in record.GetType().GetProperties())
            {
                value = (string)property.GetValue(record);

                if (value != null)
                {
                    value = value.Trim();

                    if (value == "")
                    {
                        value = null;
                    }
                }

                property.SetValue(record, value);
            }
        }

        /// <summary>
        /// Get required error message.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetRequiredMessage(int row, string field)
        {
            return string.Format("Row {0}: '{1}' is required.", row, field);
        }

        /// <summary>
        /// Get invalid length error message.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetInvalidLengthMessage(int row, string field, int length)
        {
            return string.Format("Row {0}: Value for '{1}' is more than {2} characters.", row, field, length);
        }

        /// <summary>
        /// Get invalid value error message.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetInvalidValueMessage(int row, string field, string value)
        {
            return string.Format("Row {0}: Invalid value '{2}' for '{1}'.", row, field, value);
        }

        /// <summary>
        /// Get required error message.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetCreateFailedMessage(int row, string field, string value)
        {
            return string.Format("Row {0}: Unable to create '{1}' with value {2}.", row, field, value);
        }

        /// <summary>
        /// Get items of a category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static Dictionary<string, Guid> GetCategoryItems(Guid categoryId)
        {
            var dictionay = new Dictionary<string, Guid>();

            var category = GenericHelper.GetCategory(categoryId);

            if (category != null && category.Subtaxa != null)
            {
                foreach (var item in category.Subtaxa)
                {
                    dictionay.Add(item.Title, item.Id);
                }
            }

            return dictionay;
        }

        /// <summary>
        /// Convert string to integer.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int? ConvertToInt(string data)
        {
            int? value = null;

            if (data != null)
            {
                data = data.Replace("$", "");
                data = data.Replace(",", "");
                data = data.Trim();

                if (Int32.TryParse(data, out int result))
                {
                    value = result;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static decimal? ConvertToDecimal(string data)
        {
            decimal? value = null;

            if (data != null)
            {
                data = data.Replace("$", "");
                data = data.Replace(",", "");
                data = data.Trim();

                if (Decimal.TryParse(data, out decimal result))
                {
                    value = result;
                }
            }

            return value;
        }

        /// <summary>
        /// Convert string to boolean.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ConvertToBoolean(string data)
        {
            if (data != null)
            {
                data = data.ToLower();

                if (data == "yes" || data == "true" || data == "y" || data == "1")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
