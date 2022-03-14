﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.EcommerceSystem.UserProfiles
{
    public class UserProfile:AuditedEntity<Guid>
    {
   
        public string Name { get; set; }
        public int Age { get; set; }

        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }

    }
}