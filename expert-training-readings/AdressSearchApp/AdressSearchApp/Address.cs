﻿using System;
namespace AdressSearchApp
{
    public class Address
    {
        public string state { get; set; }
        public string stateName { get; set; }
        public string city { get; set; }
        public string street { get; set; }

        public Address()
        {
            this.state = "";
            this.stateName = "";
            this.city = "";
            this.street = "";
        }
    }
}
