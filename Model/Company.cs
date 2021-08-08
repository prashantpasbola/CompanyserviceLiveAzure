using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace companyservice.Model
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("CompanyCode")]
        [Required(ErrorMessage = "CompanyCode is required")]
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "CompanyName is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "CompanyCEO is required")]
        public string CompanyCEO { get; set; }

        [Required(ErrorMessage = "CompanyTurnover is required")]
        [Range(1000000000.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than 10Cr.")]
        public double CompanyTurnover { get; set; }

        [Required(ErrorMessage = "CompanyWebsite is required")]
        public string CompanyWebsite { get; set; }

        [Required(ErrorMessage = "StockExchange is required")]
        public string StockExchange { get; set; }
    }
    public class CompanyDetails
    {
        public Company Companies { get; set; }
        public List<Stock> StockDetails { get; set; }

    }
}
