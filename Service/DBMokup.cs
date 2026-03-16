using FinalProjectAmit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FinalProjectAmit.Service
{
    public static class DBMokup
    {
        private static List<User> _users = new List<User>();

        static DBMokup()
        {
            _users.Add(new User
            {
                Id = 1,
                UserEmail = "a",
                UserPassword = "a",
                FirstName = "Amit",
                LastName = "Shlaifer",
                IsAdmin = true,
                Mobile = "0586663024"
            });

            _users.Add(new User
            {
                Id = 2,
                UserEmail = "user1@mail.com",
                UserPassword = "pass1",
                FirstName = "Omer",
                LastName = "Shlaifer",
                IsAdmin = false,
                Mobile = "0587444194"
            });

            _users.Add(new User
            {
                Id = 3,
                UserEmail = "user2@mail.com",
                UserPassword = "pass2",
                FirstName = "Ben",
                LastName = "Shlaifer",
                IsAdmin = false,
                Mobile = "0532225478"
            });
        }

        public static User? CurrentUser { get; set; }

        public static List<User> GetAllUsers()
        {
            return _users;
        }

        public static User? GetUser(string email, string password)
        {
            return _users.FirstOrDefault(u =>
                u.UserEmail == email &&
                u.UserPassword == password);
        }

        public static bool IsEmailExist(string email)
        {
            return _users.Any(u => u.UserEmail == email);
        }

        public static void AddUser(User user)
        {
            if (user != null)
                _users.Add(user);
        }

        public static void UpdateUser(User user)
        {
            if (user == null) return;

            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index >= 0)
                _users[index] = user;
        }

        public static void RemoveUser(User user)
        {
            if (user != null)
                _users.RemoveAll(u => u.Id == user.Id);
        }
    }
}