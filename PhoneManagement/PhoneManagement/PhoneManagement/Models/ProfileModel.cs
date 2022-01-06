using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class ProfileModel : INotifyPropertyChanged

    {
     
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int AccountID;
        private string AccountName;
        private string AccountPhone;
        private string AccountEmail;
        private string AccountPassword;

        public int ACCOUNTID {
            get { return AccountID; }
            set { AccountID = value;
                OnPropertyChanged("ACCOUNTID");
            }
        }
        public string ACCOUNTNAME
        {
            get { return AccountName; }
            set { AccountName = value;
                OnPropertyChanged("ACCOUNTNAME");
            }
        }
        public string ACCOUNTPHONE
        {
            get { return AccountPhone; }
            set { AccountPhone = value;
                OnPropertyChanged("ACCOUNTPHONE");
            }
        }
        public string ACCOUNTEMAIL
        {
            get { return AccountEmail; }
            set { AccountEmail = value;
                OnPropertyChanged("ACCOUNTEMAIL");
            }
        }
        public string ACCOUNTPASSWORD
        {
            get { return AccountPassword; }
            set { AccountPassword = value;
                OnPropertyChanged("ACCOUNTPASSWORD");
            }
        }


    }
}
