﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class APIContext :DbContext
    {
        public APIContext() : base("LatihanMVC3Mocules") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts{ get; set; }
    }
}