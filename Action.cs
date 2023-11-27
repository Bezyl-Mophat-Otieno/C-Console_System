using System;

namespace registrationsystem
{
    public class Action
    {
        public static void Registraton (string username , string password , string path){
            File.WriteAllText(path,username);
            File.AppendAllText(path,"\n");
            File.AppendAllText(path,password);
        }
        public static Dictionary<string,object> Login(string username , string password , string path){

            string[] data = File.ReadAllLines(path);
           
            bool isMatch = false;
            for (int i = 0; i < data.Length; i++)
            { 
                isMatch = (data[0] == username && data[1] == password) ? true : false;

                Console.WriteLine(data[0] == username);
                Console.WriteLine(data[1] == password);

            }

            Dictionary<string,object> user = new Dictionary<string,object>();
            user.Add("username",username);
            user.Add("isMatch",isMatch);

            return user;   
        }
        
    }
    
}
