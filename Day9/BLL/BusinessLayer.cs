namespace BLL;
using BOL;
using MySql.Data.MySqlClient;
using DAL;
public class BusinessLayer
{
    static MySqlConnection conn = Connect.getConnection();

    public static void InsertData(int EmployeeId1, string EmployeeName1, string CompanyName1){
        string query = "insert into RegisterEmployee values (@EmployeeId,@EmployeeName,@CompanyName)";
        conn.Open();
        MySqlCommand command = new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@EmployeeId",EmployeeId1);
        command.Parameters.AddWithValue("@EmployeeName",EmployeeName1);
        command.Parameters.AddWithValue("@CompanyName",CompanyName1);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static Employee Login(int EmployeeId, string EmployeeName){
        string query = "select * from RegisterEmployee where EmployeeId= @EmployeeId and EmployeeName = @EmployeeName";
        conn.Open();
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@EmployeeId",EmployeeId);
        command.Parameters.AddWithValue("@EmployeeName",EmployeeName);
        MySqlDataReader reader = command.ExecuteReader();
        // if(reader==null){
        //     return false;
        //     conn.Close();
        // }
        Employee e=null;
        bool flag = false;
        while(reader.Read()){
            e = new Employee(reader["CompanyName"].ToString(),reader["EmployeeName"].ToString(),int.Parse(reader["EmployeeId"].ToString()));
            flag = true;
        }
        if(flag){
            conn.Close();
            return e;
        }
        conn.Close();
        return e; 
    }

    public static List<Employee> ViewAllEmployee(){
        conn.Open();
        List<Employee> emp = new List<Employee>();
        string query = "Select * from RegisterEmployee";
        MySqlCommand command = new MySqlCommand(query,conn);
        MySqlDataReader reader = command.ExecuteReader();
        while(reader.Read()){
            Employee e = new Employee(reader["CompanyName"].ToString(),reader["EmployeeName"].ToString(),int.Parse(reader["EmployeeId"].ToString()));
            emp.Add(e);
        }
        conn.Close();
        return emp;
    }

    public static void EditEmployee(int EmployeeId1, string EmployeeName1, string CompanyName1){
        conn.Open();
        string query = "update RegisterEmployee set EmployeeName = @EName , CompanyName = @CName where EmployeeId = @EId";
        MySqlCommand command = new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@EName",EmployeeName1);
        command.Parameters.AddWithValue("@CName",CompanyName1);
        command.Parameters.AddWithValue("@EId",EmployeeId1);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static void DeleteEmployee(Employee emp){
        conn.Open();
        string query = "delete from RegisterEmployee where EmployeeId = @Eid";
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@Eid", emp.EmployeeId);
        command.ExecuteNonQuery();
        conn.Close();
    }
}
