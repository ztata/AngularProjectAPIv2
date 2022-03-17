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

        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] APITIcket _apiTicket)
        {
            Ticket result = new Ticket();
            using (TicketContext context = new TicketContext())
            {
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
