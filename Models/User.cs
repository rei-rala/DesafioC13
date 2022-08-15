namespace DesafioC13.Models
{
    class User
    {
        public long Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Mail { get; set; }

        public User()
        {
            Nombre = String.Empty;
            Apellido = String.Empty;
            NombreUsuario = String.Empty;
            Contrasena = String.Empty;
            Mail = String.Empty;
        }


        public override string ToString()
        {
            return "Producto Id#" + this.Id
                + ": [Nombre=" + Nombre
                + ", Apellido=" + Apellido
                + ", NombreUsuario=" + NombreUsuario
                + ", Contraseña=" + Contrasena
                + ", Mail=" + Mail
                + "]";
        }
    }
}
