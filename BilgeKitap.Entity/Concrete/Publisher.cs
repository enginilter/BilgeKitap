using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Entity
{
    public class Publisher : IEntity
    {
        public int PublisherId { get; set; }


        public string PublisherFirstName { get; set; }

        public string PublisherLastName { get; set; }

        public string PublisherEmail { get; set; }
        public string PublisherPhone { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
