namespace registrationsystem;

public class Book
{

    public int bookId { get; set; }
    public string bookName { get; set; }
    public string bookDesc { get; set; }

    public Book(int bookId, string bookName, string bookDesc)
    {
        this.bookId =   bookId;
        this.bookName = bookName;
        this.bookDesc = bookDesc;
    }

    public void addPublication (string path){
        File.AppendAllText(path,this.bookId.ToString());
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,this.bookName);
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,this.bookDesc);
        File.AppendAllText(path,"\n");
    }

    public static void getBooks (string path){
        string[] data = File.ReadAllLines(path);
            Console.WriteLine($"Book ID:\t{data[0]}");
            Console.WriteLine($"Book Name:\t{data[1]}");
            Console.WriteLine($"Book Description:\t{data[2]}");
    }
    public static void purchaseBook (string bookpath , string dataPath ,string orderPath, int orderId ){

        string bookId = File.ReadAllLines(bookpath)[0];
        string userId = File.ReadAllLines(dataPath)[3];

        Order order = new Order(orderId,bookId,userId);

        order.createOrder(orderPath);
    }
}
