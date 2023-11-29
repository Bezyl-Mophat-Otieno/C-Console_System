namespace registrationsystem;

public class User
{
    public string username {get;set;}
    public string password {get;set;}
    public  int userId {get;set;}
    public bool isAdmin {get;set;}

    
    public User (string username , string password , int userId , bool isAdmin=true){
        this.username = username;
        this.password = password;
        this.userId =   userId;
        this.isAdmin = isAdmin;
        
    }

    public void Registration (string path){
        File.AppendAllText(path,this.username);
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,this.password);
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,this.isAdmin.ToString());
        File.AppendAllText(path,"\n");
        File.AppendAllText(path,this.userId.ToString());
        File.AppendAllText(path,"\n");

      



        Console.WriteLine("Registration Successful");

    }
      public static  Dictionary<string,object> Login(string username , string password , string path){

            string[] data = File.ReadAllLines(path);
           
            string userId = data[3];
            bool isMatch = false;
            bool isMatchUser = false;
            bool isMatchAdmin = false;
            for (int i = 0; i < data.Length; i++)
            { 
                isMatchUser = (data[0] == username && data[1] == password) ? true : false;
                isMatchAdmin = (data[4] == username && data[5] == password) ? true : false;
                isMatch = isMatchUser || isMatchAdmin;
            }

            Dictionary<string,object> user = new Dictionary<string,object>();
            user.Add("userId",userId);
            user.Add("username",username);
            user.Add("isMatch",isMatch);
            user.Add("isAdmin",isMatchAdmin?true:false);

            return user;   
        }




}
