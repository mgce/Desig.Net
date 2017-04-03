using System;
using System.Collections.Generic;

namespace Designet.Models
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Deadline { get; set; }

        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual IList<Note> Notes { get; set; }
    }
}