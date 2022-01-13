using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class UserInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string ten;
        private string mk;

        public string Ten
        {
            get { return ten; }
            set
            {
                ten = value;
                OnPropertyChanged("Ten");
            }
        }
        public string MK
        {
            get { return mk; }
            set
            {
                mk = value;
                OnPropertyChanged("MK");
            }
        }
    }
}
