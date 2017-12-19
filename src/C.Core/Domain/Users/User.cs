using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Core.Domain.Users
{
    public class User : BaseEntity
    {/// <summary>
     /// Ctor
     /// </summary>
        public User()
        {
            this.CustomerGuid = Guid.NewGuid();
        }

        public Guid CustomerGuid { get; set; }

        public string Loginname { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
