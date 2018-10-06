using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoService.Entity
{
    public class ToDoContext: DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }


        public DbSet<AgendaItem> Items { get; set; }
        public DbSet<AgendaPicture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaItem>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("now()");


            modelBuilder.Entity<AgendaItem>()
                .HasOne(a => a.AgendaPicture)
                .WithOne(b => b.AgendaItem)
                .HasForeignKey<AgendaPicture>(b=>b.AgendaItemId);
        }
    }
}
