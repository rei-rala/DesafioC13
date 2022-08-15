namespace DesafioC13.Models
{
    class Product
    {
        public long Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Product()
        {
            Descripciones = String.Empty;
        }


        public override string ToString()
        {
            return "Producto Id#" + this.Id
                + ": [Descripciones=" + Descripciones
                + ", Costo=" + Costo
                + ", Precio venta=" + PrecioVenta
                + ", Stock=" + Stock
                + ", Id de usuario=" + IdUsuario
                + "]";
        }
    }
}
