using Acme.EcommerceSystem.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.EcommerceSystem.UserTransactions
{
    public class UserTransaction:AuditedEntity<Guid>
    {
      

        public int Amount { get; set; }
        public DateTime DateTime { get; set; }

        public Guid UserID { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
