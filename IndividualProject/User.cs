using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class User
    {
        public enum Role
        {
            Admin,
            UserWithPrivilegeView,
            UserWithPrivilegeViewEdit,
            UserWithPrivilegeViewEditDelete,
            WithoutPrivilege
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public MessageInfo Message { get; set; }
        public string Password { get; set; }
        private Role privilege;
        public Role Privilege
        {
            get
            {
                return privilege;
            }
            set
            {
                var user = new User();
                if (value == Role.Admin)
                {
                    value = Admin(user);
                    privilege = value;
                }
                if (value == Role.UserWithPrivilegeView)
                {
                    value = UserWithPrivilegeView(user);
                    privilege = value;
                }
                if (value == Role.UserWithPrivilegeViewEdit)
                {
                    value = UserWithPrivilegeViewEdit(user);
                    privilege = value;
                }
                if (value == Role.UserWithPrivilegeViewEditDelete)
                {
                    value = UserWithPrivilegeViewEditDelete(user);
                }
                if (value == Role.WithoutPrivilege)
                {
                    value = WithoutRole(user);
                }
            }
        }

        public User(int id, string name, string password, Role privilege, int IdMessage, string text, int idsender, int idreceiver)
        {
            ID = id;
            Name = name;
            Password = password;
            Privilege = privilege;
            Message = new MessageInfo()
            {
                Id = IdMessage,
                Text = text,
                IdSender = idreceiver
            };
        }

        public User()
        {
             
        }

        private static Role UserWithPrivilegeViewEditDelete(User user)
        {

            DataBaseAccess.ViewMessageAndUsers(DataBaseAccess.AccessDB());
            DataBaseAccess.InsertMessage(DataBaseAccess.AccessDB());
            DataBaseAccess.DeleteMessage(DataBaseAccess.AccessDB());

            return Role.UserWithPrivilegeViewEditDelete;
        }

        private static Role UserWithPrivilegeViewEdit(User user)
        {

            DataBaseAccess.ViewMessageAndUsers(DataBaseAccess.AccessDB());
            DataBaseAccess.InsertMessage(DataBaseAccess.AccessDB());

            return Role.UserWithPrivilegeViewEdit;
        }

        private static Role UserWithPrivilegeView(User user)
        {

            DataBaseAccess.ViewMessageAndUsers(DataBaseAccess.AccessDB());

            return Role.UserWithPrivilegeView;
        }

        private static Role Admin(User user)
        {

            AdminPrivileges(user);

            return Role.Admin;
        }

        //AdminPrivilege
        private static void AdminPrivileges(User user)
        {
            DataBaseAccess.AccessDB();
            DataBaseAccess.ViewMessageAndUsers(DataBaseAccess.AccessDB());
            DataBaseAccess.InsertMessage(DataBaseAccess.AccessDB());
            DataBaseAccess.UpadeMessage(DataBaseAccess.AccessDB());
            DataBaseAccess.DeleteMessage(DataBaseAccess.AccessDB());
            //User.CheckNameAndPassword(list, user);
        }

        private static Role WithoutRole(User user)
        {
            MessageInfo.Messenger(user);
            return Role.WithoutPrivilege;
        }
    }
}
