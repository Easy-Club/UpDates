//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ManagerEnter
    {
        public int C_id { get; set; }
        public Nullable<int> EnterpId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
    
        public virtual Enterprises Enterprises { get; set; }
    }
}