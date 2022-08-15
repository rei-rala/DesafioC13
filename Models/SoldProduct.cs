namespace DesafioC13.Models
{
    class SoldProduct
    {
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdVenta { get; set; }
        public long IdProducto { get; set; }
        
        public override string ToString()
        {
            return "ProductoVendido Id#" + this.Id
                + ": [Stock=" + Stock
                + ", IdVenta=" + IdVenta
                + ", IdProducto=" + IdProducto
                + "]";
        }
    }
}
