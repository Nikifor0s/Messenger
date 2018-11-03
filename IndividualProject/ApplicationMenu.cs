using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class ApplicationMenu
    {
        //details of the Entities
        public static void Info(User user)
        {

            user = LoginScreen.Login(DataBaseAccess.AccessDB(), user);

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine("1 to Login As Admin")
                .AppendLine("2 to Login As User with View Priviledges")
                .AppendLine("3 to Login As User with View, Edit Priviledges")
                .AppendLine("4 to Login As User with View, Edit and Delete Priviledges");
            Console.WriteLine(sb);


            var choose = Convert.ToInt32(Console.ReadLine());




            switch (choose)
            {
                case 1:
                    user.Privilege = User.Role.Admin;
                    break;
                case 2:
                    user.Privilege = User.Role.UserWithPrivilegeView;
                    break;
                case 3:
                    user.Privilege = User.Role.UserWithPrivilegeViewEdit;
                    break;
                default:
                    user.Privilege = User.Role.UserWithPrivilegeViewEditDelete;
                    break;
               
            }
        }
    }
}
