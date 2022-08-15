using System.Data;

namespace DesafioC13.Models.db
{
    class UserHandler : DbHandler
    {
        public UserHandler() : base("Usuario")
        {
        }

        public List<User> GetUsers()
        {
            List<User> userList = new();

            try
            {
                DataSet dsProductos = GetAll();

                foreach (DataRow row in dsProductos.Tables[0].Rows)
                {
                    User user = new User
                    {
                        Id = Convert.ToInt64(row["Id"]),
                        Nombre = "" + row["Nombre"].ToString(),
                        Apellido = "" + row["Apellido"].ToString(),
                        NombreUsuario = "" + row["NombreUsuario"].ToString(),
                        Contrasena = "" + row["Contraseña"].ToString(),
                        Mail = "" + row["Mail"].ToString(),
                    };
                    userList.Add(user);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en consulta a Tabla " + base.Table + ":");
                Console.WriteLine(e);
            }


            return userList;
        }

        public User GetUserById(int Id)
        {
            List<User> userList = new();
            DataSet ds = GetById(Id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                User user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = "" + row["Nombre"]?.ToString(),
                    Apellido = "" + row["Apellido"].ToString(),
                    NombreUsuario = "" + row["NombreUsuario"].ToString(),
                    Contrasena = "" + row["Contrasena"].ToString(),
                    Mail = "" + row["Mail"].ToString(),
                };
                userList.Add(user);
            }

            return userList.FirstOrDefault();
        }

        public User? LogIn(string user, string password)
        {
            User? userLogged = null;
            DataSet ds = GetByField("NombreUsuario", user);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Contraseña"].ToString() == password)
                {
                    userLogged = new User
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = "" + row["Nombre"].ToString(),
                        Apellido = "" + row["Apellido"].ToString(),
                        NombreUsuario = "" + row["NombreUsuario"].ToString(),
                        Contrasena = "" + row["Contraseña"].ToString(),
                        Mail = "" + row["Mail"].ToString(),
                    };
                }
            }
            return userLogged;
        }
    }
}