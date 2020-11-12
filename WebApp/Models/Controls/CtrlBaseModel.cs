﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlBaseModel
    {
        public string Id { get; set; }
        public string ViewName { get; set; }

        private string ReadFileText()
        {
            string pathRelative = System.Configuration.ConfigurationManager.AppSettings["PathTemplates"];
            string fileName = this.GetType().Name + ".html";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathRelative);
            path = path + fileName;

            string text = System.IO.File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop != null)
                {
                    var value = prop.GetValue(this, null).ToString();

                    var tag = string.Format("-#{0}-", prop.Name);
                    html = html.Replace(tag, value);
                }
            }
            return html;
        }
    }
}