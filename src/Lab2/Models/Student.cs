using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab2.Models
{
    public class Student
    {
        private string _phone;

        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*$", ErrorMessage = "Имя пишется русскими символами, первая буква заглавная.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения.")]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*$", ErrorMessage = "Фамилия пишется русскими символами, первая буква заглавная.")]
        public string Surname { get; set; }

        [RegularExpression(@"^[А-ЯЁ][а-яё]*$", ErrorMessage = "Отчество пишется русскими символами, первая буква заглавная.")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Название группы обязательно для заполнения.")]
        [RegularExpression(@"^[0-9M-]*$", ErrorMessage = "Группа пишется цифрами, может содержать символ \"-\" и заглавную букву \"М\".")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен для заполнения.")]
        [RegularExpression(@"^(\+7|8)?[\s-]?(\(?\d{3}\)?)[\s-]?(\d{3})[\s-]?(\d{2})[\s-]?(\d{2})$",
            ErrorMessage = "Номер телефона пишется в формате \"+79998887766\".")]
        public string Phone
        {
            get => _phone;
            set => _phone = FormatPhoneNumber(value);
        }

        [Required(ErrorMessage = "E-mail обязателен для заполнения.")]
        [RegularExpression(@"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+)", ErrorMessage = "E-mail пишется в формате \"example@gmail.com\".")]
        public string Email { get; set; }

        private string FormatPhoneNumber(string phone)
        {
            string cleaned = Regex.Replace(phone, @"[\s-()]", string.Empty);
            Match match = Regex.Match(cleaned, @"^(\+7|8)?(\d{3})(\d{3})(\d{2})(\d{2})$");

            if (match.Success)
            {
                return $"+7({match.Groups[2].Value}){match.Groups[3].Value}-{match.Groups[4].Value}-{match.Groups[5].Value}";
            }

            return phone;
        }
    }
}
