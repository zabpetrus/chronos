using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities._Base
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
