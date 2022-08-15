namespace DesafioC13.Models
{
    class Sale
    {
        public long Id { get; set; }

        public string Comentarios { get; set; }

        public Sale()
        {
            Comentarios = String.Empty;
        }


        public override string ToString()
        {
            return "ProductoVendido Id#" + this.Id
                + ": [Comentarios=" + Comentarios
                + "]";
        }
    }
}
