using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CST8259_Lab2.Models
{
    public class XMLandSchemaFileUpload
    {
        [Display(Name = "XML File")]
        public IFormFile XmlFile { get; set; }

        [Display(Name = "Schema File")]
        public IFormFile SchemaFile { get; set; }
    }
}
