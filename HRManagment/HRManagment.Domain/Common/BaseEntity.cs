using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime IsDeleted { get; set; }
    }
}
