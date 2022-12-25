using ExchangeRates.BusinessLogic.Infrastructure;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private SortableObservableCollection<CurrencyViewModel> _items = new SortableObservableCollection<CurrencyViewModel>();
        public SortableObservableCollection<CurrencyViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public ICommand ItemDragged { get; }

        public ICommand ItemDropped { get; }

        public SettingsViewModel()
        {
            ItemDragged = new Command<CurrencyViewModel>(OnItemDragged);
            ItemDropped = new Command<CurrencyViewModel>(i => OnItemDropped(i));
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
