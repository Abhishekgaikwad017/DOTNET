
using MySql.Data.MySqlClient;


//Mysql Connection to connect 

string connStr = "server=192.168.10.150;port=3306;user=dac23;password=welcome;database=dac23";
MySqlConnection conn = new MySqlConnection(connStr);
int ch;
do{


Console.WriteLine(" 1.Show All Data\n 2.Insert data \n 3.Delete the data by Id\n 4.Update rate by id\n 5.Count the number of records\n 6.Exit");
Console.WriteLine("Enter Your Choice : ");
 ch = int.Parse(Console.ReadLine());
switch(ch){
    case 1: 
            string query = "Select * from menucard";
            MySqlCommand command = new MySqlCommand(query, conn);
            
           
            try{
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read()){
                int id = int.Parse(reader["ID"].ToString());
                string name =  reader["NAME"].ToString();
                int rate = int.Parse(reader["RATE"].ToString());
                Console.Write(" ID : "+id);
                Console.Write(" NAME : "+name);
                Console.Write(" RATE : "+rate+"\n");
                }
                reader.Close();
                Console.WriteLine("------------------------------------------------");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                conn.Close();
            }

           
        break;
    case 2:
            conn.Open();
            Console.WriteLine("Enter table name : ");
            string table = Console.ReadLine();
            query = "Select count(*) from "+table;
            command = new MySqlCommand(query,conn);
            int count = int.Parse((command.ExecuteScalar().ToString()));
            int ID = ++count;
            Console.WriteLine("Enter Burger Flavour :");
            string NAME = Console.ReadLine();
            Console.WriteLine("Enter Rate : ");
            int RATE = int.Parse(Console.ReadLine().ToString());
            query = "Insert into "+table+" values(@ID,@NAME,@RATE)";
             command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@ID",ID);
            command.Parameters.AddWithValue("@NAME",NAME);
            command.Parameters.AddWithValue("@RATE",RATE);
            try{
               
                command.ExecuteNonQuery();            
                Console.WriteLine("------------------------------------------------");
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                conn.Close();
            }
            
        break;
    case 3: 
            conn.Open();
            Console.WriteLine("Enter table name : ");
            table = Console.ReadLine();
            Console.WriteLine("Enter id : ");
            ID = int.Parse(Console.ReadLine().ToString());
            query = "Delete from "+table+" where ID =@ID";
            command = new MySqlCommand(query,conn);
            command.Parameters.AddWithValue("@ID",ID);
            try{
                command.ExecuteNonQuery();
                Console.WriteLine("------------------------------------------------");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                conn.Close();
            }
           

        break;
    case 4:
            Console.WriteLine("Enter table name : ");
            table = Console.ReadLine();
            Console.WriteLine("Enter id to update :");
            ID = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine("Enter Rate to update : ");
            RATE = int.Parse(Console.ReadLine().ToString());
            query = "Update "+table+" set RATE = @RATE where ID = @ID";
            command = new MySqlCommand(query,conn);
            command.Parameters.AddWithValue("@RATE",RATE);
            command.Parameters.AddWithValue("@ID",ID);
            try{
                conn.Open();
                command.ExecuteNonQuery();
                 Console.WriteLine("------------------------------------------------");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                conn.Close();
            }
        break;
    case 5:
             Console.WriteLine("Enter table name : ");
            table = Console.ReadLine();
            query = "Select count(*) from "+table;
            command = new MySqlCommand(query,conn);
            try{
                conn.Open();
                count = int.Parse((command.ExecuteScalar().ToString()));
                Console.WriteLine("Count : "+count);
                Console.WriteLine("------------------------------------------------");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                conn.Close();
            }
        break;
        
}
}while(ch!=6);
