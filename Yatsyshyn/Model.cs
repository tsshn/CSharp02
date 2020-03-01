using System;
using System.Windows;

namespace Yatsyshyn
{
    public class Model
    {
        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { set; get; }
        public int Age { get; set; }
        public string WesternSign { get; set; }
        public string ChineseSign { get; set; }
        public bool Adult { get; private set; }

        private readonly string[] _chineseSigns =
        {
            "Rat 🐀", "Ox 🐂", "Tiger 🐅", "Rabbit 🐇", "Dragon 🐉", "Snake 🐍", "Horse 🐎", "Goat 🐐", "Monkey 🐒",
            "Rooster 🐓", "Dog 🐕", "Pig 🐖"
        };

        private readonly string[] _westernSigns =
        {
            "Aquarius ♒", "Pisces ♓", "Aries ♈", "Taurus ♉", "Gemini ♊", "Cancer ♋", "Leo ♌", "Virgo ♍", "Libra ♍",
            "Scorpio ♏",
            "Sagittarius ♐", "Capricorn ♑"
        };

        public bool Calculator()
        {
            Age = CalcAge();
            if (!CheckAge()) return false;
            Adult = IsAdult();
            ChineseSign = CalcChineseHoroscope();
            WesternSign = CalcWesternHoroscope();
            return true;
        }

        private int CalcAge()
        {
            return (DateTime.Today - Convert.ToDateTime(Birthday)).Days / 365;
        }

        private bool IsAdult()
        {
            return Age >= 18;
        }

        public bool CheckBirthday()
        {
            return Birthday?.Day == DateTime.Today.Day && Birthday?.Month == DateTime.Today.Month;
        }

        private bool CheckAge()
        {
            return Age <= 135 && DateTime.Today >= Birthday?.Date;
        }

        private string CalcChineseHoroscope()
        {
            int? index = Birthday?.Year - 1900;
            if (index < 0) index *= -1;
            index %= 12;
            if (index != null) return _chineseSigns[(int) index];
            return "";
        }

        private string CalcWesternHoroscope()
        {
            var month = Birthday?.Month;
            var day = Birthday?.Day;
            switch (month)
            {
                case 01 when day >= 20:
                case 02 when day <= 18:
                    return _westernSigns[0];
                case 02 when day >= 19:
                case 03 when day <= 20:
                    return _westernSigns[1];
                case 03 when day >= 21:
                case 04 when day <= 19:
                    return _westernSigns[2];
                case 04 when day >= 20:
                case 05 when day <= 20:
                    return _westernSigns[3];
                case 05 when day >= 21:
                case 06 when day <= 20:
                    return _westernSigns[4];
                case 06 when day >= 21:
                case 07 when day <= 22:
                    return _westernSigns[5];
                case 07 when day >= 23:
                case 08 when day <= 22:
                    return _westernSigns[6];
                case 08 when day >= 23:
                case 09 when day <= 22:
                    return _westernSigns[7];
                case 09 when day >= 23:
                case 10 when day <= 22:
                    return _westernSigns[8];
                case 10 when day >= 23:
                case 11 when day <= 21:
                    return _westernSigns[9];
                case 11 when day >= 22:
                case 12 when day <= 21:
                    return _westernSigns[10];
                case 12 when day >= 22:
                case 01 when day <= 19:
                    return _westernSigns[11];
                default: return "";
            }
        }

        #endregion

        #region Constructors

        public Model()
        {
        }

        public Model(string firstName, string lastName, string email, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
        }

        public Model(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Model(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        #endregion
    }
}