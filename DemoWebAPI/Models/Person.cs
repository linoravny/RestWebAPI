﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}