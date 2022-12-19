using System.ComponentModel;

namespace ExchangeRates.Presentation.ViewModels
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {
        private string _charCode;
        public string CharCode
        {
            get { return _charCode; }
            set
            {
                if (_charCode != value)
                {
                    _charCode = value;
                    NotifyPropertyChanged("CharCode");
                }
            }
        }

        private string _scale;
        public string Scale
        {
            get { return _scale; }
            set
            {
                if (_scale != value)
                {
                    _scale = value;
                    NotifyPropertyChanged("Scale");
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _rate1;
        public string Rate1
        {
            get { return _rate1; }
            set
            {
                if (_rate1 != value)
                {
                    _rate1 = value;
                    NotifyPropertyChanged("Rate1");
                }
            }
        }

        private string _rate2;
        public string Rate2
        {
            get { return _rate2; }
            set
            {
                if (_rate2 != value)
                {
                    _rate2 = value;
                    NotifyPropertyChanged("Rate2");
                }
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    NotifyPropertyChanged("IsActive");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
