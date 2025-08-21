using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSNStore.DataLayer.DataAccess
{
    public interface IProductDataAccess
    {
        decimal? GetPriceByName(string productName);

        int CreateProduct(string productName, decimal price);
    }
}
