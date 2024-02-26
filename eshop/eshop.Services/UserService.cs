using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services
{
    public class UserService : IUserService
    {

        private List<User> _users = new List<User>()
        {
            new(){ Id=1, Name="Türkay", UserName="turkay", Email="turkay.urkmez@dinamikzihin.com", Password="123456", Role="Admin"},
            new(){ Id=2, Name="İlker", UserName="ilker", Email="ilker.dalar@turkcell.com.tr", Password="123456", Role="Editor"},
            new(){ Id=3, Name="Gizem", UserName="gizem", Email="gizem.akinci@turkcell.com.tr", Password="123456", Role="Editor"},
            new(){ Id=4, Name="Ünal", UserName="unal", Email="una.uysal@turkcell.com.tr", Password="123456", Role="Client"},

        };
        public User ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
