using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemMVCPart.Models
{
    public class DrugsViewModel
    {
        public int DrugId { get; set; }
        [Required]
        public string DrugName { get; set; }
        [Required]
        public Nullable<int> Quantity { get; set; }
        [Required]
        public Nullable<System.DateTime> Expiry_Date { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<decimal> SupplierId { get; set; }

    }
}