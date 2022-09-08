using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;
using System;
using System.IO;

namespace AvonHMO.API.Helpers
{

    public class EmailTemplateBuilder
    {
        IWebHostEnvironment _env;
        string _emailTemplate;
        public EmailTemplateBuilder(IWebHostEnvironment env, string emailTemplate)
        {
            _env = env;
            _emailTemplate = emailTemplate;
        }


        public string BuildTemplate<T>(T templateObj) where T : new()
        {

            var _rootPath = _env.ContentRootPath;
            var templatePath = Path.Combine(_rootPath, $"EmailTemplates\\{_emailTemplate}.html");
            var body = string.Empty;

            using (StreamReader reader = new StreamReader(templatePath))
            {
                body = reader.ReadToEnd();
            }

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var value = prop.GetValue(templateObj)?.ToString();
                body = body
                    .Replace($"%{prop.Name}%", value);

            }

            return body;
        }

    }
}
