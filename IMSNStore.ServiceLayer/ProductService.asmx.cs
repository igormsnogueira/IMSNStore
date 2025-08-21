using IMSNStore.Data.DataAccess;
using IMSNStore.DataLayer.DataAccess;
using System;
using System.Web.Services;

namespace IMSNStore.Services
{
    [WebService(Namespace = "http://www.imsnstore.com/services/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ProductService : System.Web.Services.WebService
    {
        private readonly IProductDataAccess _dataAccess;

        public ProductService(IProductDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public ProductService() : this(new ProductDataAccess())
        {
        }

        [WebMethod]
        public decimal? GetProductPrice(string productName)
        {
            return _dataAccess.GetPriceByName(productName);
        }

        [WebMethod]
        public int CreateProduct(string productName, decimal price)
        {
            return _dataAccess.CreateProduct(productName, price);
        }
    }
}