//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asp_mvc_2.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class menu
    {
        public menu()
        {
            this.laporans = new HashSet<laporan>();
        }
    
        public int id_menu { get; set; }
        public string menu1 { get; set; }
        public Nullable<int> stock { get; set; }
        public Nullable<int> harga { get; set; }
    
        public virtual ICollection<laporan> laporans { get; set; }
    }
}