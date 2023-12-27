
namespace Banking;
using Notification;
using Taxation;

public class Account{
    
    public event NotificationOperation underBalance;
    public event TaxOperation overBlance;
    public float balance{get;set;}
    public string name{get;set;}
    public Account(string name,float amt){
        this.name = name;
        // if(amt<5000){
        //     underBalance($"{this.name} deposite min 5000");
        // }
        this.balance = amt;
    }

    public void Deposite(float amt){
        this.balance+=amt;
        
        Console.WriteLine($"Hello {this.name} , You have deposite {amt}");
        Console.WriteLine($"Current balance is {this.balance} ");
        if(this.balance>=100000){
            overBlance(500);
        }

    }

    public void Withdraw(float amt){
        this.balance-=amt;
        Console.WriteLine($"Hello {this.name} , You have withdraw {amt}");
        Console.WriteLine($"Current balance is {this.balance} ");
        if(this.balance<=10000){
            underBalance($"{this.name}"," Your account is blocked");
        }
    }

    
    
}