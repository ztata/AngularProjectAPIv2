using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AngularProject.DataObjects
{
    public class ResolvedTicket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ticketId { get; set; }

        [Required]
        [StringLength(40)]
        public string ticketName { get; set; }

        [Required]
        [StringLength(40)]
        public string createdBy { get; set; }

        [Required]
        [StringLength(400)]
        public string ticketDescription { get; set; }

        public bool isResolved { get; set; }

        [StringLength(40)]
        public string completedBy { get; set; }

        [StringLength(400)]
        public string resolutionNotes { get; set; }
    }
}
