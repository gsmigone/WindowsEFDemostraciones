﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using WindowsEFEscuela.Models;
using System.Data.Entity;
namespace WindowsEFEscuela.Data
{
    public class DBEFEscuelaContext : DbContext
    {
        public DBEFEscuelaContext(): base("keyDBEFEscuela") { }
        
            public DbSet<Alumno> Alumnos { get; set; }
            public DbSet<Profesor> Profesores { get; set; }
       
    }
}
