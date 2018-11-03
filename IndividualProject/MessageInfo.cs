using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class MessageInfo
    {
        public int Id { get; set; }        
        public int IdSender { get; set; }
        public int IdReceiver { get; set; }
        public DateTime DateOfSub { get; set; }
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value.Length > 250)
                    throw new ArgumentException($"Expected length at most 250. Message failed");
                text = value;
            }
        }
        //Messeger Details od Message and User
        public static void Messenger(User user)
        {
            
            LoginScreen.Login(DataBaseAccess.AccessDB(), user);
            DataBaseAccess.ViewMessageAndUsers(DataBaseAccess.AccessDB());
            DataBaseAccess.InsertMessage(DataBaseAccess.AccessDB());
        }
        
    }
}
