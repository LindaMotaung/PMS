using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Entities
{
    public class AccountVaultEntity
    {
        public int Id { get; set; }
        public string applicationName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string notes { get; set; }
        public string applicationUrl { get; set; }
    }
}
