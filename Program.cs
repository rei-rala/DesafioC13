using DesafioC13.Models;
using DesafioC13.Models.db;

public class Program
{
    static void Main(string[] args)
    {
        // Product
        ProductHandler ph = new();

        List<Product> productos = ph.GetProducts();

        foreach (Product producto in productos)
        {
            Console.WriteLine(producto);
        }

        Product? p100 = ph.GetProductById(100);

        Console.WriteLine("PRODUCTO #100? " + (p100 == null ? "NO Encontrado" : p100));

        // SoldProduct
        PrintSep();
        SoldProductHandler soldProductTable = new();
        List<SoldProduct> soldProducts = soldProductTable.GetSoldProducts();

        foreach (SoldProduct soldProduct in soldProducts)
        {
            Console.WriteLine(soldProduct);
        }


        // Sale
        PrintSep();
        SalesHandler salesTable = new();

        List<Sale> sales = salesTable.GetSales();

        foreach (Sale sale in sales)
        {
            Console.WriteLine(sale);
        }

        // User
        PrintSep();
        UserHandler userTable = new();

        List<User> users = userTable.GetUsers();
        foreach (User user in users)
        {
            Console.WriteLine(user);
        }


        // LOG IN rudimentario
        PrintSep();


        Console.WriteLine("Ingrese su nombre de usuario: ");
        string nombreUsuario = "" + Console.ReadLine();
        Console.WriteLine("Ingrese su contraseña: ");
        string contrasena = "" + Console.ReadLine();
        User? userLogged = userTable.LogIn(nombreUsuario, contrasena);

        Console.WriteLine(
            userLogged != null
            ? "Inicio de sesión como " + userLogged.Nombre + " " + userLogged.Apellido + "<" + userLogged.Mail + ">"
            : "Usuario o contraseña incorrectos"
            );

    }

    static void PrintSep()
    {
        Console.WriteLine("\n\n");
    }
}