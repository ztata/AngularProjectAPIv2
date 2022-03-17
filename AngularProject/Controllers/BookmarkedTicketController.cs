using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularProject.DataObjects;


namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkedTicketController : ControllerBase
    {
        // GET: api/<BookmarkedTicketController>
        [HttpGet]
        public async Task<AllBookmarkedTickets> ReturnAllTickets()
        {
            AllBookmarkedTickets tickets = new AllBookmarkedTickets();
            using (TicketContext context = new TicketContext())
            {
                tickets.allBookmarkedTickets = context.BookmarkedTickets.ToList();
            }

            return tickets;
        }

        // POST api/<BookmarkedTicketController>
        [HttpPost]
        public void Post([FromBody] BookmarkedTicket ticket)
        {
            BookmarkedTicket result = new BookmarkedTicket();
            using (TicketContext context = new TicketContext())
            {
                result.ticketId = ticket.Id;
                result.userId = ticket.userId;
                result.ticketName = ticket.ticketName;
                result.ticketDescription = ticket.ticketDescription;
                result.createdBy = ticket.createdBy;
                result.isResolved = ticket.isResolved;
                result.completedBy = ticket.completedBy;
                result.resolutionNotes = ticket.resolutionNotes;
                context.BookmarkedTickets.Add(result);
                context.SaveChanges();
            }
        }

        // DELETE api/<BookmarkedTicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (TicketContext context = new TicketContext())
            {
                context.BookmarkedTickets.Remove(context.BookmarkedTickets.Where(x => x.Id == id).First());
                context.SaveChanges();
            }
        }
    }
}
