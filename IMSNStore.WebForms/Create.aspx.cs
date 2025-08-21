using IMSNStore.Application.ProductServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMSNStore.Application
{
    public partial class _Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ProductService client = new ProductService();

                string productName = txtNewProductName.Text;

                string priceText = txtNewProductPrice.Text;
                decimal price;

                if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out price))
                {
                    lblCreateStatus.Text = "Erro: O valor do preço não é um número válido.";
                    return;
                }

                int newId = client.CreateProduct(productName, price);

                lblCreateStatus.Text = $"Produto '{productName}' criado com sucesso! ID: {newId}";
            }
            catch (Exception ex)
            {
                lblCreateStatus.Text = $"Erro ao criar o produto: {ex.Message}";
            }
        }
    }
}