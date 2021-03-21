using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CST8259_Lab2.Models
{
    public class XmlValidationError
    {
        [Display(Name = "XML Elemnt")]
        public string Element { get; set; }

        [Display(Name = "Error Type")]
        public string ErrorType { get; set; }

        [Display(Name = "Line Number")]
        public int Line { get; set; }

        [Display(Name = "Column Number")]
        public int Column { get; set; }

        [Display(Name = "Error Message")]
        public string Message { get; set; }
    }
}
