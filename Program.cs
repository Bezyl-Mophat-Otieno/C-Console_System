namespace registrationsystem;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Choose an option : \n 1. Register \n 2. Login \n 3. Exit");

        string option = Console.ReadLine();
        int userId = 1;
        if(option == "1"){
        // creating the storage path
        string path = @"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/data.txt";
        Console.WriteLine("Welcome to the registration system \n");
        Console.WriteLine("Enter Your Username");
        string username = Console.ReadLine();
        Console.WriteLine("Enter Your Password");
        string password = Console.ReadLine();
        // Register the User
        User user = new User(username , password , userId);

        user.Registration(path);

        }else if(option == "2"){
        Console.WriteLine("Welcome to the Login system \n");
        // Login the user 
        bool loginStatus = false;
        bool loginStatusAdmin = false;
        bool loginStatusUser = false;
        do {
         string path = @"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/data.txt";
         Console.WriteLine("Enter Your Username");
         string username = Console.ReadLine();
         Console.WriteLine("Enter Your Password");
         string password = Console.ReadLine();

         var dataDictionary = User.Login(username!,password!,path);
         loginStatusAdmin = (bool)dataDictionary["isAdmin"]?true:false;
         loginStatusUser = (bool)dataDictionary["isAdmin"]?false:(bool)dataDictionary["isMatch"];
         

         if(loginStatusUser){
               
                string bookPath =@"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/book.txt"; 
                string orderPath = @"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/order.txt";
                string dataPath = @"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/data.txt";
                Console.WriteLine($"Welcome:{dataDictionary["username"]}");
                Console.WriteLine("BOOKS IN STORE \n\n");
                Console.WriteLine("___CHOOSE BASED ON ID_____");
                Book.getBooks(bookPath); 

                string bookChoice = Console.ReadLine(); 

                if(bookChoice == File.ReadAllLines(bookPath)[0]){
                    int orderId = 1;
                    Book.purchaseBook(bookPath,dataPath,orderPath,orderId);

                } else{
                    Console.WriteLine("Book Selected Does not Exists");
                }

                break;
         } else if(loginStatusAdmin){
                // create a book and add it to the store specifically in a file book.txt2
                // File.Create(@"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/book.txt");

                Book book1 = new Book (1,"Introduction","Introduction to C#");
                book1.addPublication(@"C:\Users\Mophat\OneDrive - Teach2Give\Desktop\registrationsystem/store/book.txt");                
                Console.WriteLine("Welcome:Mr.Admin");
                break;

         }else{
                Console.WriteLine("Invalid Username or Password");
         }
            
        }while(!loginStatusUser);

        }


    }
}
