namespace BOL;

public class Employee
{
    public String CompanyName{get; set;}
    public String EmployeeName{get; set;}
    public int EmployeeId{get; set;}

    public Employee(string CompanyName, string EmployeeName, int EmployeeId){
        this.CompanyName = CompanyName;
        this.EmployeeName = EmployeeName;
        this.EmployeeId = EmployeeId;
    }

    public override string ToString(){
        return (this.CompanyName+" "+ this.EmployeeName+" "+ this.EmployeeId);
    }
}
