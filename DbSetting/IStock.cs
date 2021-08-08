using companyservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace companyservice.DbSetting
{
    interface IStock
    {
        List<Stock> GetStocks();

        Stock GetStock(Guid id);
    }
}
