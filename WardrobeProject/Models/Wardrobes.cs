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
    
    public partial class Wardrobes
    {
        public int WardrobeID { get; set; }
        public int TopID { get; set; }
        public int BottomID { get; set; }
        public int ShoesID { get; set; }
        public int AccessoriesID { get; set; }
    
        public virtual Accessories Accessories { get; set; }
        public virtual Bottoms Bottoms { get; set; }
        public virtual Shoes Shoes { get; set; }
        public virtual Tops Tops { get; set; }
    }
}
