using _1115.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1115.ViewModels
{
    internal class MainViewModel:ViewModelBase
    {
        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty SurnameProperty;
        private static readonly DependencyProperty IsEnglishProperty;
        private static readonly DependencyProperty SelectedSummaryItemProperty;
        static MainViewModel()
        {
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(MainViewModel));
            SurnameProperty = DependencyProperty.Register("Surname", typeof(string), typeof(MainViewModel));
            IsEnglishProperty = DependencyProperty.Register("English", typeof(bool), typeof(MainViewModel));
            SelectedSummaryItemProperty = DependencyProperty.Register("SelectedSummaryItem", typeof(SummaryModel), typeof(MainViewModel));
        }
        MainViewModel()
        {
            Summaries.Add(new SummaryModel("Name1", "Surname1", true));
            Summaries.Add(new SummaryModel("Name2", "Surname2", true));
            Summaries.Add(new SummaryModel("Name3", "Surname3", true));
            Summaries.Add(new SummaryModel("Name4", "Surname4", true));
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public string Surname
        {
            get { return(string)GetValue(SurnameProperty);}
            set { SetValue(SurnameProperty, value);}
        }
        public bool IsEnglish
        {
            get { return (bool)GetValue(IsEnglishProperty); }
            set { SetValue(IsEnglishProperty, value); }
        }
        public SummaryModel SummaryModel
        {
            get { return (SummaryModel)GetValue(SelectedSummaryItemProperty); }
            set { SetValue(SelectedSummaryItemProperty, value); }
        }
        public ObservableCollection<SummaryModel> Summaries { get; set; }
    }
}
