//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class EmplyeeInfoDB
    {
        public int idInfo { get; set; }
        public string IdEmloyee { get; set; }
        public string ExpLevel { get; set; }
        public System.DateTime StartingDate { get; set; }
        public decimal Salary { get; set; }
        public int VacationDay { get; set; }
    
        public virtual EmployeeDB EmployeeDB { get; set; }
    }
}
