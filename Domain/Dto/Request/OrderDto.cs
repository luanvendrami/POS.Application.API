using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Request
{
    public class OrderDto
    {
        public int IdOrder { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}
