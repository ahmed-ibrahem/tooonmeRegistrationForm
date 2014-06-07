using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class dbContext :DbContext
    {
        public DbSet<CustomerViewModel> Customers { get; set; }
    }
}