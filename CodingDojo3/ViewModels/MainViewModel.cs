using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingDojo3.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private List<StockEntry> stock;
        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();
        private Currencies selectedCurrency;
        public ObservableCollection<StockEntryViewModel> Items { get => items; set => items = value; }

        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                RaisePropertyChanged("SelectedCurrency");
            }
        }

        public Array Currencies
        {
            get => Enum.GetValues(typeof(Currencies));
        }

        public MainViewModel()
        {
            SampleManager sample = new SampleManager();
            stock = sample.CurrentStock.OnStock;
            foreach(var item in sample.CurrentStock.OnStock)
            {
                items.Add(new StockEntryViewModel(item));
            }
        }

        
    }
}
