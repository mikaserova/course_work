﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hotel_newEntities : DbContext
    {
        public hotel_newEntities()
            : base("name=hotel_newEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<additional_service> additional_service { get; set; }
        public virtual DbSet<cleaning_schedule> cleaning_schedule { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<client_type> client_type { get; set; }
        public virtual DbSet<credential> credential { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<employee_position> employee_position { get; set; }
        public virtual DbSet<entrance_log> entrance_log { get; set; }
        public virtual DbSet<parking_spot> parking_spot { get; set; }
        public virtual DbSet<parking_type> parking_type { get; set; }
        public virtual DbSet<payment> payment { get; set; }
        public virtual DbSet<payment_type> payment_type { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<room> room { get; set; }
        public virtual DbSet<room_type> room_type { get; set; }
        public virtual DbSet<service_request> service_request { get; set; }
        public virtual DbSet<working_schedule> working_schedule { get; set; }
    }
}
