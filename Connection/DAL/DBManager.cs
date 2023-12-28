namespace DAL.connect;
using BOL;
using MySql.Data.MySqlClient;

public class DBManager{
      public static string connstr ="server=localhost;port=3306;user=root;password=Welcome@123;database=prac";
      public static List<Product> getAllDetails(){
            MySqlConnection conn = new MySqlConnection(connstr);
           
            string querry = "select * from Product";
            MySqlCommand cmd = new MySqlCommand(querry,conn);
            List<Product> ls = new List<Product>();
            try{
                 
                  conn.Open();
                  MySqlDataReader reader = cmd.ExecuteReader();
                  while(reader.Read()){
                        int id = int.Parse((reader["ID"]).ToString());
                        string title = reader["TITLE"].ToString();
                        double price = double.Parse((reader["PRICE"]).ToString());
                        Product p = new Product(id,title,price);
                        ls.Add(p);
                  }
                 reader.Close();
            }
            
            catch(Exception e){
                  Console.WriteLine(e.Message);
            }
            finally{
                  conn.Close();
            }
           return ls;
      }
      
      public static void Insertdata(string title,double price){
            MySqlConnection conn = new MySqlConnection(connstr);
            
            string query = "Select count(*) from Product";
            MySqlCommand cmd = new MySqlCommand(query,conn);
            try{
                conn.Open();
                int count = int.Parse((cmd.ExecuteScalar().ToString()));
                int ID = ++count;
                query = "insert into Product values(@id,@title,@price)";
                cmd = new MySqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@id",ID);
                cmd.Parameters.AddWithValue("@title",title);
                cmd.Parameters.AddWithValue("@price",price);
                cmd.ExecuteNonQuery();
            }catch(Exception e){
                  Console.WriteLine(e.Message);
            }finally{
                  conn.Close();
            }
      }

      public static void deleteData(string title){
            MySqlConnection conn = new MySqlConnection(connstr);
           
            try{
                  conn.Open();
                  string querry = "delete from product where TITLE = @title";
                  MySqlCommand cmd = new MySqlCommand(querry,conn);
                  cmd.Parameters.AddWithValue("@title",title);
                  cmd.ExecuteNonQuery();

            } catch(Exception e){
                  Console.WriteLine(e.Message);
            }
            finally{
                  conn.Close();
            }
      }
      
}
