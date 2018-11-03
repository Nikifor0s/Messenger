using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class MainApplication
    {
        //method tha choose CRUD or MEssenger 
        public static void MainApp()
        {
            User user = new User();

            Console.WriteLine("Select 1 For DataBase Information and 2 for Messenger");
            var choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    ApplicationMenu.Info(user);
                    break;
                case 2:
                    user.Privilege = User.Role.WithoutPrivilege;
                    break;
            }

        }
    }
}
