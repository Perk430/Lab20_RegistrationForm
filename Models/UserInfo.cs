using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab20_RegistrationForm.Models
{
    public class UserInfo
    {
        private string FirstName;
        private string LastName;
        private string Email;
        private string Phone;
        private string Password;

        public string UFirstName
        {
            get
            {
                return FirstName;
            }

            set
            {
                FirstName = value;
            }
        }

        public string ULastName
        {
            get
            {
                return LastName;
            }

            set
            {
                LastName = value;
            }
        }

        public string UEmail
        {
            get
            {
                return Email;
            }

            set
            {
                Email = value;
            }
        }

        public string UPhone
        {
            get
            {
                return Phone;
            }

            set
            {
                Phone = value;
            }
        }

        public string UPassword
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }

        public UserInfo(): this("","","","","")
        {
            //FirstName = "";
            //LastName = "";
            //Email = "";
            //Phone = "";
            //Password = "";
        }

        public UserInfo(string firstName, string lastName, string email, string phone, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}