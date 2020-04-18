using MyBlogCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogCore
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
            Email = email;
            Name = name;
        }

        public User(User user)
        {
            Id = user.Id;
            CreatedAt = user.CreatedAt;
            LastModified = user.LastModified;
            Email = user.Email;
            Name = user.Name;
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
    }
}
