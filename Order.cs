namespace registrationsystem;

public class Order
{

    
    public int orderId { get; set; }
    public string bookId { get; set; }
    public string userId { get; set; }

    public Order(int orderId, string bookId, string userId)
    {
        this.orderId = orderId;
        this.bookId = bookId;
        this.userId = userId;
    }

    public void createOrder ( string path ){
        File.WriteAllText(path,$"OrderId: {this.orderId.ToString()}");
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,$"BookId: {this.bookId}");
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,$"UserId: {this.userId}");
        File.AppendAllText(path,"\n");


        Console.WriteLine("The order has been recieved successfully");

    }

}
