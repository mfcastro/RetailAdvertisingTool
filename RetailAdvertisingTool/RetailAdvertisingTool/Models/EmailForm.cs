using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RetailAdvertisingTool.Models
{
    public class EmailForm
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        
        public string Message { get; set; }

        [Required]
        [Display(Name ="Vendor Email")]
        public string VendorEmail { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

    }
}