using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProject.DataObjects
{
    public class APITIcket
    {
        public string ticketName { get; set; }

        public string createdBy { get; set; }

        public string ticketDescription { get; set; }

        public string completedBy { get; set; }

        public string resolutionNotes { get; set; }
    }
}
