using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    [DataContract]
    public class User
    {
        public User()
        {
            
        }

        [DataMember(IsRequired = true)]
        public int UserId { get; set; }

        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        [DataMember(IsRequired = false)]
        public string LastName { get; set; }

        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public string Email { get; set; }
    }
}
