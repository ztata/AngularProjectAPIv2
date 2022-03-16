using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularProject.DataObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolvedTicketController : ControllerBase
    {
        // GET: api/<ResolvedTicketController>
        [HttpGet]
        public async Task<AllResolvedTickets> ReturnAllTickets()
        {
            AllResolvedTickets tickets = new AllResolvedTickets();
            using (TicketContext context = new TicketContext())
            {
                tickets.allResolvedTickets = context.ResolvedTickets.ToList();
            }

            return tickets;
        }

        // POST api/<ResolvedTicketController>
        [HttpPost]
        public void Post([FromBody] ResolvedTicket ticket)
        {
            ResolvedTicket result = new ResolvedTicket();
            using (TicketContext context = new TicketContext())
            {
                result.ticketId = ticket.Id;
                result.ticketName = ticket.ticketName;
                result.ticketDescription = ticket.ticketDescription;
                result.createdBy = ticket.createdBy;
                result.isResolved = ticket.isResolved;
                result.completedBy = ticket.completedBy;
                result.resolutionNotes = ticket.resolutionNotes;
                context.ResolvedTickets.Add(result);
                context.SaveChanges();
            }
        }

        // DELETE api/<ResolvedTicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (TicketContext context = new TicketContext())
            {
                context.ResolvedTickets.Remove(context.ResolvedTickets.Where(x => x.Id == id).First());
                context.SaveChanges();
            }
        }
    }
}
