namespace DAL;
using MySql.Data.MySqlClient;

public class Connect
{
    private static MySqlConnection conn = null;
    
    public static MySqlConnection getConnection(){
        if(conn==null){
            // conn = new MySqlConnection();
            String connstr= "server=192.168.10.150;port=3306;user=dac23;password=welcome;database=dac23";
            conn = new MySqlConnection(connstr);
        }
        return conn;
        
    }
}
