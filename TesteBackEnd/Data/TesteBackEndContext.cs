#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackEnd.Model;

    public class TesteBackEndContext : DbContext
    {
        public TesteBackEndContext (DbContextOptions<TesteBackEndContext> options)
            : base(options)
        {
        }

        public DbSet<TesteBackEnd.Model.PersonalModels> PersonalModels { get; set; }

        public DbSet<TesteBackEnd.Model.AddressModel> AddressModel { get; set; }


    }
