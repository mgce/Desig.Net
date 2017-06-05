using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Designet.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<Order> Orders { get; set; }
    }
}