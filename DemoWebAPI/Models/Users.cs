using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DemoWebAPI.Models
{
    [DataContract]
    [BsonIgnoreExtraElements]
    public class Users
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }
        [DataMember]
        public string first_name { get; set; }
        [DataMember]
        public string last_name { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public ArrayList status { get; set; }
        [DataMember]
        public DateTime? created_date { get; set; }
    }

    //public enum Status
    //{
    //   regular,
    //   express,
    //   admin
    //}
}