using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingMall.Extensions
{
    public class MyFileExtensionsAttribute : ValidationAttribute
    {
        private readonly List<string> _allowedExtensions;

        public MyFileExtensionsAttribute(string fileExtensions)
        {
            _allowedExtensions = fileExtensions.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList(); ;
        }

        public override bool IsValid(object file)
        {
            if (file != null)
            {
                var image = (HttpPostedFileBase)file;
                return _allowedExtensions.Any(a => a.Contains(image.FileName.Split(new char[] { '.'}).Last()));
            }

            return true;
        }
    }
}