using System.Data;

namespace DesafioC13.Models.db
{
    class SoldProductHandler : DbHandler
    {
        public SoldProductHandler() : base("ProductoVendido")
        {
        }

        public List<SoldProduct> GetSoldProducts()
        {
            List<SoldProduct> productList = new();

            try
            {
                DataSet ds = GetAll();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    SoldProduct soldProduct = new SoldProduct
                    {
                        Id = Convert.ToInt64(row["Id"]),
                        Stock = Convert.ToInt32(row["Stock"]),
                        IdVenta = Convert.ToInt64(row["IdVenta"]),
                        IdProducto = Convert.ToInt64(row["IdProducto"]),
                    };
                    productList.Add(soldProduct);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en consulta a Tabla " + base.Table + ":");
                Console.WriteLine(e);
            }


            return productList;
        }

        public SoldProduct GetSoldProductById(int Id)
        {
            List<SoldProduct> soldProductsList = new();
            DataSet ds = GetById(Id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                SoldProduct soldProduct = new SoldProduct
                {
                    Id = Convert.ToInt64(row["Id"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    IdVenta = Convert.ToInt64(row["IdVenta"]),
                    IdProducto = Convert.ToInt64(row["IdProducto"])
                };
                soldProductsList.Add(soldProduct);
            }


            return soldProductsList.FirstOrDefault();
        }
    }
}
