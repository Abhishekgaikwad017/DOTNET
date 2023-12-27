namespace Taxation;

 public delegate void TaxOperation(float amt);
public class TaxService{
   
    public void PayIncomeTax(float amount){

        Console.WriteLine( "Income Tax : "+ amount + "is deducted from your Bank Account");
        
    }

    public void PaysalesTax(float amount){
        Console.WriteLine( "Sales Tax : "+ amount + "is deducted from your Bank Account");
        
    }

    public  void PayServiceTax(float amount){

        Console.WriteLine( "Service Tax : "+ amount + "is deducted from your Bank Account");   
    }

    public void PayGSTTax(float amount){
           Console.WriteLine( "GST Tax : "+ amount + "is deducted from your Bank Account");
    }
}