using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _08_CRUD_Personas_UI.Models
{
    public class _08_CRUD_Personas_UIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public _08_CRUD_Personas_UIContext() : base("name=_08_CRUD_Personas_UIContext")
        {
        }

        public System.Data.Entity.DbSet<_08_CRUD_Personas_Entities.clsPersona> clsPersonas { get; set; }
    }
}
