
using System.Data;

namespace DesafioC13.Models.db
{
    class SalesHandler : DbHandler
    {
        public SalesHandler() : base("Venta")
        {
        }

        public List<Sale> GetSales()
        {
            List<Sale> salesList = new();

            try
            {
                DataSet dsProductos = GetAll();

                foreach (DataRow row in dsProductos.Tables[0].Rows)
                {
                    Sale sale = new Sale
                    {
                        Id = Convert.ToInt64(row["Id"]),
                        Comentarios = "" + row["Comentarios"].ToString(),
                    };
                    salesList.Add(sale);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en consulta a Tabla " + base.Table + ":");
                Console.WriteLine(e);
            }


            return salesList;
        }

        public Sale GetSaleById(int Id)
        {
            List<Sale> salesList = new();

            DataSet ds = GetById(Id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Sale sale = new Sale
                {
                    Id = Convert.ToInt64(row["Id"]),
                    Comentarios = "" + row["Comentarios"].ToString()
                };
                salesList.Add(sale);
            }

            return salesList.FirstOrDefault();
        }
    }

}
