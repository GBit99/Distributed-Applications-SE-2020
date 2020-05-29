using System;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using MC.Business.DTOs;

namespace MC.WcfServices
{
    public class CustomUserCredentialsValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            var users = new UserDto[]
            {
                new UserDto
                {
                    Email = "test1Email",
                    FullName ="test1FullName",
                    Password = "test1Password",
                    Username = "test1Username"
                },
                new UserDto
                {
                    Email = "test2Email",
                    FullName ="test2FullName",
                    Password = "test2Password",
                    Username = "test2Username"
                },
                new UserDto
                {
                    Email = "test3Email",
                    FullName ="test3FullName",
                    Password = "test3Password",
                    Username = "test3Username"
                },
                new UserDto
                {
                    Email = "test4Email",
                    FullName ="test4FullName",
                    Password = "test4Password",
                    Username = "test4Username"
                },
                new UserDto
                {
                    Email = "test5Email",
                    FullName ="test5FullName",
                    Password = "test5Password",
                    Username = "test5Username"
                },
                new UserDto
                {
                    Email = "test6Email",
                    FullName ="test6FullName",
                    Password = "test6Password",
                    Username = "test6Username"
                }
            };

            if (userName == null || password == null)
            {
                throw new ArgumentException();
            }

            if (!users.Any(u => u.Username == u.Username && u.Password == u.Password))
            {
                throw new FaultException("Unknown username or incorrect password");
            }
        }
    }
}