using BOL;
using MySql.Data.MySqlClient;
namespace DAL;

public class DBManager
{

  public static List<Product> GetAllProducts()
  {
    List<Product> ls = new List<Product>();
    MySqlConnection conn = new MySqlConnection();
    conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac15; password=welcome; database=dac15;";
    string query = "select * from product";
    MySqlCommand command = new MySqlCommand(query, conn);
    try
    {
      conn.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        int id = int.Parse(reader["pid"].ToString());
        string pname = reader["pnm"].ToString();
        int qty = int.Parse(reader["qyt"].ToString());
        float price = float.Parse(reader["price"].ToString());
        Product p = new Product(id, pname, qty, price);
        ls.Add(p);
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    finally
    {
      conn.Close();
    }
    return ls;
  }
  public static Product GetAllProductById(int id)
  {
    Product p = null;
    MySqlConnection conn = new MySqlConnection();
    conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac15; password=welcome; database=dac15;";
    string query = "select * from product where pid=" + id;
    MySqlCommand command = new MySqlCommand(query, conn);
    try
    {
      conn.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        int id1 = int.Parse(reader["pid"].ToString());
        string pname = reader["pnm"].ToString();
        int qty = int.Parse(reader["qyt"].ToString());
        float price = float.Parse(reader["price"].ToString());
        p = new Product(id1, pname, qty, price);

      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    finally
    {
      conn.Close();
    }
    return p;
  }
  public static void AddProduct(int id, string name, int qty, float price)
  {
    MySqlConnection conn = new MySqlConnection();
    conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac15; password=welcome; database=dac15;";
    string query = "insert into product values ('" + id + "','" + name + "','" + qty + "', '" + price + "' )";
    MySqlCommand command = new MySqlCommand(query, conn);
    try
    {
      conn.Open();
      command.ExecuteNonQuery();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    finally
    {
      conn.Close();
    }
  }
}