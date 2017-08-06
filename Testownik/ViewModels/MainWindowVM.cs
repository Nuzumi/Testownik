﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Testownik.Model;
using Testownik.Repository;

namespace Testownik.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        public ICommand ToBrowserCommand { get; set; }
        public ICommand ToTestCommand { get; set; }
        public RWRepository<Model.Test> testRepo;

        private ObservableCollection<Test> TestList;
        private Model.Test selectedTest;
        public Model.Test SelectedTest
        {
            set
            {
                selectedTest = value;
                UpdateQuestionAmount();
            }
        }
        public int SelectedTestQuestionAmount { get; set; }

        public MainWindowVM()
        {
            ToBrowserCommand = new DelegateCommand<Window>(ToBrowser);
            ToTestCommand = new DelegateCommand<Window>(ToTest);
            testRepo = new RWRepository<Model.Test>(new TestownikContext());
            MessageBox.Show(testRepo.GetById(1).ToString());
        }

        private void UpdateQuestionAmount()
        {
            //zaimplemoentowac
        }

        //Commends Start

        private void ToBrowser(Window window)
        {
            BaseQuestionBrowser trybEdycji = new BaseQuestionBrowser();
            BaseQuestionBrowserVM baseQuestionBrowserVm = new BaseQuestionBrowserVM();
            trybEdycji.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            trybEdycji.DataContext = baseQuestionBrowserVm;
            trybEdycji.Show();
            window.Close();
        }

        private void ToTest(Window window)
        {
            Test test = new Test();
            TestVM testVM = new TestVM();
            test.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            test.DataContext = testVM;
            test.Show();
            window.Close();
        }

        //Commends End
    }
}
