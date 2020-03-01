﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Yatsyshyn
{
    internal sealed class ViewModel : INotifyPropertyChanged
    {
        private readonly Model _person = new Model();

        public string FirstName
        {
            get => _person.FirstName;
            set => _person.FirstName = value;
        }

        public string LastName
        {
            get => _person.LastName;
            set => _person.LastName = value;
        }

        public string Email
        {
            get => _person.Email;
            set => _person.Email = value;
        }

        public DateTime Birthday
        {
            set
            {
                _person.Birthday = value;
                OnPropertyChanged();
            }
            get
            {
                if (_person.Birthday != null) return (DateTime) _person.Birthday;
                return DateTime.Now;
            }
        }

        public int Age
        {
            get => _person.Age;
            set => _person.Age = value;
        }

        public bool Adult => _person.Adult;

        public string ChineseSign
        {
            get => _person.ChineseSign;
            set => _person.ChineseSign = value;
        }

        public string WesternSign
        {
            get => _person.WesternSign;
            set => _person.WesternSign = value;
        }

        private async void Processor()
        {
            var valid = true;
            await Task.Run(() => valid = _person.Calculator());
            if (valid)
            {
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Birthday));
                OnPropertyChanged(nameof(Adult));
                OnPropertyChanged(nameof(ChineseSign));
                OnPropertyChanged(nameof(WesternSign));
            }
            else
                MessageBox.Show("Please enter the correct date of birth");

            if (_person.CheckBirthday())
                MessageBox.Show("Happy Birthday");
        }

        private RelayCommand<object> _command;

        public RelayCommand<object> Command => _command ?? (_command = new RelayCommand<object>(o =>
            Processor(), o => CanExecute()));

        private bool CanExecute()
        {
            return !string.IsNullOrEmpty(_person.FirstName) &&
                   !string.IsNullOrEmpty(_person.LastName) &&
                   !string.IsNullOrEmpty(_person.Email) &&
                   !string.IsNullOrWhiteSpace(_person.Birthday.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}