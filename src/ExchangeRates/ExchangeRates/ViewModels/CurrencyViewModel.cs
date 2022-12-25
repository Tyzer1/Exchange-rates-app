using System.ComponentModel;
using Xamarin.CommunityToolkit.ObjectModel;

namespace ExchangeRates.Presentation.ViewModels
{
    public class CurrencyViewModel :ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _charCode;
        public string CharCode
        {
            get { return _charCode; }
            set { SetProperty(ref _charCode, value); }
        }

        private string _scale;
        public string Scale
        {
            get { return _scale; }
            set { SetProperty(ref _scale, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _rate1;
        public string Rate1
        {
            get { return _rate1; }
            set { SetProperty(ref _rate1, value); }
        }

        private string _rate2;
        public string Rate2
        {
            get { return _rate2; }
            set { SetProperty(ref _rate2, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        private bool _isBeingDragged;
        public bool IsBeingDragged
        {
            get { return _isBeingDragged; }
            set { SetProperty(ref _isBeingDragged, value); }
        }
    }
}
