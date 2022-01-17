﻿using Strategy.Business.Models;
using Strategy.Business.Strategies.SalesTax;
using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails 
                { 
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            // The strategy pattern is a behavioral design pattern and the idea is that you
            // choose a suitable strategy based on user input
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

            if (destination == "sweden")
                order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
            else if (destination == "us")
                order.SalesTaxStrategy = new UsaSalesTaxStrategy();

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            Console.WriteLine(order.GetTax());
        }
    }
}