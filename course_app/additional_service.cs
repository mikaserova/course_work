//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace course_app
{
    using System;
    using System.Collections.Generic;
    
    public partial class additional_service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public additional_service()
        {
            this.service_request = new HashSet<service_request>();
        }
    
        public int additional_service_id { get; set; }
        public string service_name { get; set; }
        public decimal service_cost { get; set; }
        public decimal service_price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service_request> service_request { get; set; }
    }
}
