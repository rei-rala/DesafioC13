


using System.Data;

namespace DesafioC13.Models.db
{
    class ProductHandler : DbHandler
    {

        public ProductHandler() : base("Producto")
        {
        }

        public List<Product> GetProducts()
        {
            List<Product> productList = new();

            DataSet dsProductos = GetAll();

            foreach (DataRow row in dsProductos.Tables[0].Rows)
            {
                Product product = new()
                {
                    Id = Convert.ToInt64(row["Id"]),
                    Descripciones = "" + row["Descripciones"].ToString(),
                    Costo = Convert.ToDouble(row["Costo"]),
                    PrecioVenta = Convert.ToDouble(row["PrecioVenta"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"])
                };
                productList.Add(product);
            }

            return productList;
        }

        public Product GetProductById(int Id)
        {
            List<Product> products = new();
            DataSet ds = GetById(Id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Product product = new Product
                {
                    Id = Convert.ToInt64(row["Id"]),
                    Descripciones = "" + row["Descripciones"].ToString(),
                    Costo = Convert.ToDouble(row["Costo"]),
                    PrecioVenta = Convert.ToDouble(row["PrecioVenta"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"])
                };

                products.Add(product);
            }

            return products.FirstOrDefault();
        }
    }
}
