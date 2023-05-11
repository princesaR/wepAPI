using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CoronaDb: DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<CoronaPatient> CoronaPatients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=LAPTOP-0B2M9DCK\\MSSQLSERVER02;database=corona;trusted_connection=true;encrypt=true;TrustServerCertificate=True");
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CoronaPatient>(entity =>
        //    {
        //        entity.HasKey(e => e.code);
        //    });

        //    modelBuilder.Entity<Vaccination>()
        //          .HasKey(v => new { v.VaccinationId, v.Id })

        //          ;
        //    modelBuilder.Entity<Member>()
        //   .Property(m => m.FirstName)
        //   .IsRequired();

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasKey(m => new { m.Id });

            modelBuilder.Entity<Vaccination>()

               .HasOne(p => p.Member)
                 .WithMany()
                 .HasForeignKey(p => p.Id); 

            modelBuilder.Entity<Vaccination>()
            .HasKey(v => new { v.Id, v.VaccinationId });

            modelBuilder.Entity<CoronaPatient>()
                   .HasOne(p => p.Member)
                   .WithMany()
                   .HasForeignKey(p => p.Id)
                   .IsRequired();
        
            // Other configurations...

            base.OnModelCreating(modelBuilder);
       
            // Configure relationships
            
        }


    }
}
