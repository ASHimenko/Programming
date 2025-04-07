using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
    public class Contact
    {
        private string _name;
        private string _surname;
        private string _phoneNumber;

        public Contact() { }

        public Contact(string name, string surname, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Имя не может быть пустым.");
                _name = value;
                AssertStringContainsOnlyLetter(value, nameof(Name));
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Фамилия не может быть пустой.");
                _surname = value;
                AssertStringContainsOnlyLetter(value, nameof(Surname));
                _surname = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Номер телефона не может быть пустым.");
                _phoneNumber = value;
            }
        }

        private void AssertStringContainsOnlyLetter(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.All(char.IsLetter))
            {
                throw new ArgumentException($"{propertyName} должен содержать только символы английского алфавита.");
            }
        }
    }
}
