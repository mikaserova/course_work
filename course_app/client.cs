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
    
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            this.reservation = new HashSet<reservation>();
        }
    
        public int client_id { get; set; }
        public string client_first_name { get; set; }
        public string client_last_name { get; set; }
        public string client_middle_name { get; set; }
        public string client_phone_number { get; set; }
        public string client_email { get; set; }
        public string client_passport_serial_number { get; set; }
        public string client_notes { get; set; }
        public int client_type_id { get; set; }
    
        public virtual client_type client_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservation { get; set; }
    }
}