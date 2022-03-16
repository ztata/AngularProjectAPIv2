using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AngularProject.DataObjects
{
    public class TicketContext : DbContext
    {
        //by god this is amazing
        //test3
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<BookmarkedTicket> BookmarkedTickets { get; set; }
        public DbSet<ResolvedTicket> ResolvedTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HelpTicketsSecondTry;Trusted_Connection=True;");
        }




    }
}
