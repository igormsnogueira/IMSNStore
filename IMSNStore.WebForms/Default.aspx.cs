using IMSNStore.Application.ProductServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMSNStore.Application
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductService client = new ProductService();

                decimal? preco = client.GetProductPrice(txtProduto.Text);

                if (preco.HasValue)
                {
                    lblPreco.Text = preco.Value.ToString("C"); 
                    lblStatus.Text = "Consulta realizada com sucesso.";
                }
                else
                {
                    lblPreco.Text = "N/A";
                    lblStatus.Text = "Produto não encontrado.";
                }
            }
            catch(Exception ex)
            {
                lblPreco.Text = "ERRO";
                lblStatus.Text = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}