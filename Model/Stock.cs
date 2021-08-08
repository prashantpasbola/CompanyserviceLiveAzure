using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace companyservice.Model
{
    public class Stock
    {
        public Guid Id { get; set; }
        public string CompanyCode { get; set; }

        public string StockPrice { get; set; }

        public string Startdate { get; set; }

        public string Enddate { get; set; }

    }
}
