using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Common
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// This returns a formatted exception
        /// </summary>
        /// <param name="ex">exception to be formated</param>
        public static string FormatException(Exception ex)
        {
            var message = ex.Message;
            //Add the inner exception if present (showing only the first 50 characters of the first exception)
            if (ex.InnerException == null) return message;
            if (message.Length > 150)
                message = message.Substring(0, 150);

            message += "...->" + ex.InnerException.Message + "...->" + (ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : "");

            return message;
        }

        /// <summary>
        /// This returns a collection of Validation error  messages for a model
        /// </summary>
        /// <summary>
        /// Fields decorated with required attributes will be validated 
        /// </summary>
        /// <param name="model">Generic Model</param>
        public static string[] ModelRequiredFieldValidation<T>(T model) where T : new()
        {
            var errorMessage = new List<string>();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.GetCustomAttributes(false).Any(m => m.GetType().Name.ToLower() == "requiredattribute"))
                {
                    var value = prop.GetValue(model)?.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        errorMessage.Add($"{prop.Name.ToUpper()}: is a required field");
                    }
                }
            }

            return errorMessage.ToArray();
        }
    }
}
