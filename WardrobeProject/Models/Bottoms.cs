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
    
    public partial class Bottoms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bottoms()
        {
            this.Wardrobes = new HashSet<Wardrobes>();
        }
    
        public int BottomID { get; set; }
        public string BottomName { get; set; }
        public string BottomType { get; set; }
        public string BottomColor { get; set; }
        public string BottomSeason { get; set; }
        public string BottomOccasion { get; set; }
        public string BottomPhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wardrobes> Wardrobes { get; set; }
    }
}
