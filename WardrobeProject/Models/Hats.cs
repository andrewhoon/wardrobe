//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WardrobeProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hats
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hats()
        {
            this.Accessories = new HashSet<Accessories>();
        }
    
        public int HatsID { get; set; }
        public string HatsName { get; set; }
        public string HatsType { get; set; }
        public string HatsColor { get; set; }
        public string HatsSeason { get; set; }
        public string HatsOccasion { get; set; }
        public string HatsPhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accessories> Accessories { get; set; }
    }
}
