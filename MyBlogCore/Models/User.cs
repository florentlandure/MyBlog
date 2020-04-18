using MyBlogCore.Utils;
using MyBlogCore.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyBlogCore.Models
{
    public class User : Entity, IEquatable<User>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Logo { get; set; }
        public DateTime BirthDate { get; set; }

        public User(string email, string name)
        {
            ValidateEmail(email);
            ValidateName(name);
            Email = email;
            Name = name;
        }

        public User(User user) : this(user.Email, user.Name)
        {
            Id = user.Id;
            CreatedAt = user.CreatedAt;
            LastModified = user.LastModified;
            Password = user.Password;
            Logo = user.Logo;
            BirthDate = user.BirthDate;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Email == other.Email &&
                   Name == other.Name &&
                   Password == other.Password &&
                   Logo == other.Logo &&
                   BirthDate == other.BirthDate;
        }

        public override int GetHashCode()
        {
            int hashCode = -1964362231;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Logo);
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        private void ValidateEmail(string email)
        {
            if (!EmailValidator.IsValidEmail(email))
            {
                throw new ArgumentException("Email is not valid");
            }
        }

        private void ValidateName(string name)
        {
            ValidationUtils.ValidateEmptyArgument(name, "Name cannot be empty");
        }
    }
}
