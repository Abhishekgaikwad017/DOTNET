namespace Notification;
public delegate void NotificationOperation(string to,string content);
public class NotificationService{

public void SendEmail(string to, string content){
    Console.WriteLine( "Email is Sent to "+ to );
}

public void SendSMS(string to, string content){
    Console.WriteLine( "SMS is Sent to "+ to );
}



public void SendWhatsAppMessage(string to, string content){
    Console.WriteLine( "Whatsapp is Sent to "+ to );
}

}