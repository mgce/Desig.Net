using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Designet.Models
{
    public class Note
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Created { get; set; }

        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}