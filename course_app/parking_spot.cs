//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace course_app
{
    using System;
    using System.Collections.Generic;
    
    public partial class parking_spot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public parking_spot()
        {
            this.entrance_log = new HashSet<entrance_log>();
        }
    
        public int parking_spot_id { get; set; }
        public string number { get; set; }
        public Nullable<int> type_id { get; set; }
        public Nullable<int> reservation_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<entrance_log> entrance_log { get; set; }
        public virtual reservation reservation { get; set; }
        public virtual parking_type parking_type { get; set; }
    }
}
