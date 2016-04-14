using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailAdvertisingTool.Models
{
    [Authorize]
    public class AdvertisingOffer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "TY Offer")]
        public string TYOfferCopy { get; set; }

        [Display(Name = "TY Offer Price")]
        [DataType(DataType.Currency)]
        public double TYOfferPrice { get; set; }

        [Display(Name = "TY Item Description")]
        public string TYItemToAdvertise { get; set; }

        [Display(Name = "TY Prep Info")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double TYOfferPrep { get; set; }

        [Display(Name = "TY ST%")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public double TYOfferSaleThru { get; set; }

        [Display(Name = "TY Inventory Level")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double TYInventoryLevel { get; set; }

        [Display(Name = "MerchID")]
        public string MerchID { get; set; }

        [Display(Name = "LY Offer")]
        public string LYOfferCopy { get; set; }

        [Display(Name = "LY Offer Price")]
        public double LYOfferPrice { get; set; }

        [Display(Name = "LY Item Description")]
        public string LYItemToAdvertise { get; set; }

        [Display(Name = "LY Prep Info")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double LYOfferPrep { get; set; }

        [Display(Name = "LY ST%")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public double LYOfferSaleThru { get; set; }

        [Display(Name = "LY Inventory Level")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double LYInventoryLevel { get; set; }



    }
}