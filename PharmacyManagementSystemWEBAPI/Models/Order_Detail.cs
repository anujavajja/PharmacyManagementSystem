//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmacyManagementSystemWEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Detail()
        {
            this.Order_Details1 = new HashSet<Order_Detail>();
            this.Order_Details12 = new HashSet<Order_Detail>();
        }
    
        public int Order_Id { get; set; }
        public int Drug_Id { get; set; }
        public int User_Id { get; set; }
        public int Quantity { get; set; }
        public System.DateTime Expiry_Date { get; set; }
        public decimal Total_Amount { get; set; }
        public System.DateTime OrderPickedup { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Details1 { get; set; }
        public virtual Order_Detail Order_Details { get; set; }
        public virtual Order_Detail Order_Details11 { get; set; }
        public virtual Order_Detail Order_Details2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Details12 { get; set; }
        public virtual Order_Detail Order_Details3 { get; set; }
    }
}
