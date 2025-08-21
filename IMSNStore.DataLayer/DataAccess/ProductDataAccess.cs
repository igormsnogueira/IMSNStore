using IMSNStore.DataLayer.DataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Configuration; 
using System.Data;

namespace IMSNStore.Data.DataAccess
{
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;

        public decimal? GetPriceByName(string productName)
        {
            decimal? price = null;

            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                // Usa `OracleCommand` para executar a stored procedure.
                using (OracleCommand cmd = new OracleCommand("SP_GET_PRODUCT_PRICE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_name", OracleDbType.Varchar2, productName, ParameterDirection.Input);
                    cmd.Parameters.Add("p_price", OracleDbType.Decimal, ParameterDirection.Output);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery(); // Execute Procedure

                        object result = cmd.Parameters["p_price"].Value;

                        if (result != DBNull.Value)
                        {
                            OracleDecimal oraclePrice = (OracleDecimal)result;
                            if (!oraclePrice.IsNull)
                            {
                                price = oraclePrice.Value;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error when getting product price on Data.", ex);
                    }
                }
            }
            return price;
        }

        public int CreateProduct(string productName, decimal price)
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("SP_CREATE_PRODUCT", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_name", OracleDbType.Varchar2, productName, ParameterDirection.Input);
                    cmd.Parameters.Add("p_price", OracleDbType.Decimal, price, ParameterDirection.Input);

                    cmd.Parameters.Add("p_new_id", OracleDbType.Int32, ParameterDirection.Output);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        object result = cmd.Parameters["p_new_id"].Value;
                        if (result != DBNull.Value)
                        {
                            OracleDecimal oracleId = (OracleDecimal)result;

                            if (!oracleId.IsNull)
                            {
                                newId = Convert.ToInt32(oracleId.Value);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error when creating new product.", ex);
                    }
                }
            }
            return newId;
        }
    }
}