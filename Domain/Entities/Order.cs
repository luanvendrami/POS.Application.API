﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order 
    {
        public int IdOrder { get; private set; }
        public string? SpecialInstructions { get; private set; }

        public Order(int idOrder, string? specialInstructions)
        {
            IdOrder = idOrder;
            SpecialInstructions = specialInstructions;
        }

        public Order()
        {
        }
    }
}