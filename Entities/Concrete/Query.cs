﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Query:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        
        public short CategoryId { get; set; }
        public short StatusId { get; set; }
        public short PriorityId { get; set; }
        public short QueryTypeId { get; set; }
        public int SenderId { get; set; }
        public int CreatorId { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public QueryType QueryType { get; set; }
        public User Creator { get; set; }
        public User Sender { get; set; }

    }
}
