using ExchangeRates.BusinessLogic.Infrastructure;
using ExchangeRates.Presentation.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ExchangeRates.Presentation.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        private SettingsController _controller;
        private SortableObservableCollection<CurrencyViewModel> _items = new SortableObservableCollection<CurrencyViewModel>();
        public SortableObservableCollection<CurrencyViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public INavigation Navigation { get; set; }
        public ICommand ItemDragged { get; }
        public ICommand ItemDropped { get; }
        public ICommand Back { get; }
        public ICommand SaveAndExit { get; }

        public SettingsViewModel(INavigation pageNav)
        {
            Navigation = pageNav;
            ItemDragged = new Command<CurrencyViewModel>(OnItemDragged);
            ItemDropped = new Command<CurrencyViewModel>(i => OnItemDropped(i));
            Back = new Command(OnBack);
            SaveAndExit = new Command(OnSaveAndExit);
            _controller = new SettingsController();
            InitViewModel();
        }

        private async void InitViewModel()
        {
            try
            {
                var settings = await _controller.GetSettingsAsync();
                int counter = 0;
                foreach (var c in settings)
                {
                    c.Id = counter++;
                }

                Items =
                    new SortableObservableCollection<CurrencyViewModel>(settings) { SortingSelector = i => i.Id };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnBack()
        {
            Navigation.PopAsync();
        }

        private void OnSaveAndExit()
        {
            _controller.SaveSettings(Items);
            Navigation.PopAsync();
        }

        private void OnItemDragged(CurrencyViewModel item)
        {
            Items.ForEach(i => i.IsBeingDragged = item == i);
        }

        private Task OnItemDropped(CurrencyViewModel item)
        {
            var itemToMove = _items.First(i => i.IsBeingDragged);
            var itemToInsertBefore = item;
            if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
                return Task.CompletedTask;
            Items.Remove(itemToMove);
            Items.Remove(itemToInsertBefore);
            var firstItemPlace = itemToInsertBefore.Id;
            itemToInsertBefore.Id = itemToMove.Id;
            itemToMove.Id = firstItemPlace;
            Items.Add(itemToMove);
            Items.Add(itemToInsertBefore);

            return Task.CompletedTask;
        }
    }
}
