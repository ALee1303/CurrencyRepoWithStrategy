using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfCurrencyProject.ViewModel;
using CurrencyProject;
using System.Collections.ObjectModel;

namespace UnitTestWpfAppCurrency
{
    [TestClass]
    public class UnitTestCurrencyRepoViewModel
    {

        ICurrencyRepo repo;
        CurrencyRepoViewModel vm;

        public UnitTestCurrencyRepoViewModel()
        {

        }

        [TestMethod]
        public void Coins_For_ComboBoxCoins_Collections_AreSame()
        {
            //Arrange
            repo = new USCurrencyRepo();
            vm = new CurrencyRepoViewModel(repo);

            ObservableCollection<ICoin> testCoinsforcdCoins;

            //Act
            testCoinsforcdCoins = vm.CoinType;
            //Assert
            CollectionAssert.AreEqual(((USCurrencyRepo)repo).CurrencyList, testCoinsforcdCoins);

        }

        //TODO test INotifyPropertyChanged
    }
}
