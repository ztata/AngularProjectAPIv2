using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Test two

namespace AngularProject.DataObjects
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

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
