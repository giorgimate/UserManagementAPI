using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.BaseEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
