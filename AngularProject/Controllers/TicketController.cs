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
    public class TicketController : ControllerBase
    {
        // GET: api/<TicketController>
        [HttpGet]
        public async Task<AllTickets> ReturnAllTickets()
        {
            AllTickets tickets = new AllTickets();
            using (TicketContext context = new TicketContext())
            {
                tickets.allTickets = context.Tickets.ToList();
            }

            return tickets;
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<Ticket> ReturnTicketById(int id)
        {
            Ticket ticket = null;
            using (TicketContext context = new TicketContext())
            {
                ticket = context.Tickets.Where(x => x.Id == id).First();
            }

            return ticket;
        }

        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] APITIcket _apiTicket)
        {
            Ticket result = new Ticket();
            using (TicketContext context = new TicketContext())
            {
                //result.Id = context.Tickets.Max(x => x.Id) + 1;
                result.ticketName = _apiTicket.ticketName;
                result.ticketDescription = _apiTicket.ticketDescription;
                result.createdBy = _apiTicket.createdBy;
                result.isResolved = false;
                result.completedBy = _apiTicket.completedBy;
                result.resolutionNotes = _apiTicket.resolutionNotes;
                context.Tickets.Add(result);
                context.SaveChanges();
            }
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void MarkAsresolved([FromBody] Ticket updatedTicket)
        {
            Ticket result = new Ticket();
            using (TicketContext context = new TicketContext())
            {
                result = context.Tickets.Where(x => x.Id == updatedTicket.Id).First();
                result.ticketName = updatedTicket.ticketName;
                result.ticketDescription = updatedTicket.ticketDescription;
                result.createdBy = updatedTicket.createdBy;
                result.isResolved = updatedTicket.isResolved;
                result.completedBy = updatedTicket.completedBy;
                result.resolutionNotes = updatedTicket.resolutionNotes;

                context.SaveChanges();
            }
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (TicketContext context = new TicketContext())
            {
                context.Tickets.Remove(context.Tickets.Where(x => x.Id == id).First());
                context.SaveChanges();
            }
        }
    }
}
