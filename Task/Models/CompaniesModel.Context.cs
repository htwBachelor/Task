﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class STPEntities : DbContext
    {
        public STPEntities()
            : base("name=STPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CompaniesDB> CompaniesDBs { get; set; }
        public virtual DbSet<EmployeeDB> EmployeeDBs { get; set; }
        public virtual DbSet<EmplyeeInfoDB> EmplyeeInfoDBs { get; set; }
    }
}