using Banking;
using Notification;
using Taxation;


TaxService act1 = new TaxService();
NotificationService nt1 = new NotificationService();
// Console.WriteLine($"Hello {act1.name} , Youre acc is created and u'r balance is {act1.balance} ");

// act1.Deposite(10000);
// act1.Withdraw(5000);
TaxOperation pit = new TaxOperation(act1.PayIncomeTax);
TaxOperation pst = new TaxOperation(act1.PayServiceTax);


NotificationOperation se = new NotificationOperation(nt1.SendEmail);
NotificationOperation ss = new NotificationOperation(nt1.SendSMS);
NotificationOperation sw = new NotificationOperation(nt1.SendWhatsAppMessage);

Account acc = new Account("abhi",50000);
acc.underBalance+=se;
acc.underBalance+=ss;
acc.underBalance+=sw;
acc.overBlance+= pit;
acc.overBlance+=pst;
acc.Deposite(200000);
acc.Withdraw(240000);



