﻿using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private RelayCommand btnDeleteClicked;
        private RelayCommand btnAddClicked;
        private StockEntryViewModel selectedItem;
        private SampleManager sample;

        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                RaisePropertyChanged("SelectedCurrency");
                ConvertPrices();
            }
        }

        private void ConvertPrices()
        {
            foreach (var item in Items)
            {
                item.CalculatePriceFromEuro(SelectedCurrency);
            }
        }

        public Array Currencies
        {
            get => Enum.GetValues(typeof(Currencies));
        }

        public MainViewModel()
        {
            sample = new SampleManager();
            stock = sample.CurrentStock.OnStock;
            BtnDeleteClicked = new RelayCommand(DeleteItem);
            BtnAddClicked = new RelayCommand(AddItem);

            foreach (var item in sample.CurrentStock.OnStock)
            {
                items.Add(new StockEntryViewModel(item));
            }
        }

        public StockEntryViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public RelayCommand BtnDeleteClicked
        {
            get { return btnDeleteClicked; }
            set { btnDeleteClicked = value; }
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        public RelayCommand BtnAddClicked
        {
            get { return btnAddClicked; }
            set { btnAddClicked = value; }
        }

        private void AddItem()
        {
            Items.Add(new StockEntryViewModel());
        }


    }
}
