//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Auth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calamviec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calamviec()
        {
            this.Chitietcalams = new HashSet<Chitietcalam>();
        }
    
        public string Maca { get; set; }
        public Nullable<double> Tienca { get; set; }
        public Nullable<System.TimeSpan> TGbatdau { get; set; }
        public Nullable<System.TimeSpan> TGKThuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietcalam> Chitietcalams { get; set; }
    }
}