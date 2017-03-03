using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Designet.Models
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Deadline { get; set; }

        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}