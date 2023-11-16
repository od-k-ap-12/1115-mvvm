using _1115.Commands;
using _1115.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Input;

namespace _1115.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty SurnameProperty;
        private static readonly DependencyProperty PhoneProperty;
        private static readonly DependencyProperty BioProperty;
        private static readonly DependencyProperty IsEnglishProperty;
        private static readonly DependencyProperty IsGermanProperty;
        private static readonly DependencyProperty SelectedSummaryItemProperty;

        static MainViewModel()
        {
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(MainViewModel));

            SurnameProperty = DependencyProperty.Register("Surname", typeof(string), typeof(MainViewModel));

            PhoneProperty = DependencyProperty.Register("Phone", typeof(string), typeof(MainViewModel));

            BioProperty = DependencyProperty.Register("Bio", typeof(string), typeof(MainViewModel));

            IsEnglishProperty = DependencyProperty.Register("English", typeof(bool), typeof(MainViewModel));

            IsGermanProperty = DependencyProperty.Register("German", typeof(bool), typeof(MainViewModel));

            SelectedSummaryItemProperty = DependencyProperty.Register("SelectedSummaryItem", typeof(SummaryModel), typeof(MainViewModel));

        }

        public MainViewModel()
        {
            Summaries = new ObservableCollection<SummaryModel>();
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }

        public string Bio
        {
            get { return (string)GetValue(BioProperty); }
            set { SetValue(BioProperty, value); }
        }

        public bool IsEnglish
        {
            get { return (bool)GetValue(IsEnglishProperty); }
            set { SetValue(IsEnglishProperty, value); }
        }

        public bool IsGerman
        {
            get { return (bool)GetValue(IsGermanProperty); }
            set { SetValue(IsGermanProperty, value); }
        }

        public SummaryModel SelectedSummaryItem
        {
            get { return (SummaryModel)GetValue(SelectedSummaryItemProperty); }
            set { SetValue(SelectedSummaryItemProperty, value); }
        }

        public ObservableCollection<SummaryModel> Summaries { get; set; }

        DelegateCommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(SaveSummary, CanSaveSummary);
                }

                return saveCommand;
            }
        }

        private void SaveSummary(object obj)
        {
            Summaries.Add(new SummaryModel(Name, Surname, Phone, Bio, IsEnglish, IsGerman));

            FileStream stream = null;
            DataContractJsonSerializer jsonFormatter = null;
            stream = new FileStream("../../summaries.json", FileMode.Create);
            jsonFormatter = new DataContractJsonSerializer(typeof(List<SummaryModel>));
            jsonFormatter.WriteObject(stream, Summaries);
            stream.Close();
            MessageBox.Show("Сериализация успешно выполнена!");
        }

        private bool CanSaveSummary(object obj)
        {
            return true;
        }

        DelegateCommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new DelegateCommand(ClearSummary, CanClearSummary);
                }

                return clearCommand;
            }
        }

        private void ClearSummary(object obj)
        {
            Name = "";
            Surname = "";
            Phone = "";
            Bio = "";
            IsEnglish = false;
            IsGerman = false;
        }

        private bool CanClearSummary(object obj)
        {
            return true;
        }

        DelegateCommand showCommand;

        public ICommand ShowCommand
        {
            get
            {
                if (showCommand == null)
                {
                    showCommand = new DelegateCommand(ShowSummary, CanShowSummary);
                }

                return showCommand;
            }
        }

        private bool CanShowSummary(object obj)
        {
            return SelectedSummaryItem != null;
        }

        private void ShowSummary(object obj)
        {
            SummaryView summaryView = new SummaryView();
            SummaryViewModel summaryModel = new SummaryViewModel(SelectedSummaryItem);
            summaryView.DataContext = summaryModel;
            summaryView.Show();
        }
    }
}
