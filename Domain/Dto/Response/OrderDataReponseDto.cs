﻿using Domain.Dto.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Response
{
    public class OrderDataReponseDto
    {
        public int IdOrder { get; set; }
        public List<DrinkOrderDto>? Drink { get; set; }
        public List<GrillOrderDto>? Grill { get; set; }
        public List<OrderFriesDto>? Fries { get; set; }
        public List<SaladOrderDto>? Salad { get; set; }

        public OrderDataReponseDto(List<DrinkOrderDto>? drink, List<GrillOrderDto>? grill, List<OrderFriesDto>? fries, List<SaladOrderDto>? salad)
        {
            Drink = drink;
            Grill = grill;
            Fries = fries;
            Salad = salad;
        }
    }
}