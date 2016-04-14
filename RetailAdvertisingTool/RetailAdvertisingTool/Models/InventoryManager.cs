using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetailAdvertisingTool.Models
{
    public class InventoryManager
    {
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Cost $")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal CostPrice__c { get; set; }

        [Display(Name = "Owned $")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal OwnedPrice__c { get; set; }

        [Display(Name = "Retail $")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal RetailCost__c { get; set; }

        [Display(Name = "Current Inventory")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double CurrentInventory__c { get; set; }

        [Display(Name = "On Order Inventory")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double InventoryOnOrder__c { get; set; }

        [Display(Name = "Sample In House")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public bool SampleInHouse__c { get; set; }
    }
}