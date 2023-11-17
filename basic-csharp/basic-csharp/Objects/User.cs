using basic_csharp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Cart Cart { get; set; }
    }

}
