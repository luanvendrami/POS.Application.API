﻿using Domain.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface IDrinkOrderService
    {
        void SendDrinkOrder(DrinkOrderDto order);
    }
}
