using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CurrencyProject;

namespace UnitTestWpfAppCurrency
{
    [TestClass]
    public class UnitTestSaveableCurrencyRepo
    {

        WindowUSCurrencyRepo repo;

        public UnitTestSaveableCurrencyRepo()
        {
            repo = new WindowUSCurrencyRepo(
                new List<ICoin>()
                {
                    new Penny(),
                    new Nickel(),
                    new Quarter()
                });
        }

        [TestMethod]
        public void SaveableCurrenyRepo_Saving_DefaultPath()
        {
            //Arrange
            string realPath;
            string defaultPath;

            //Act
            defaultPath = "MyFile.bin";
            realPath = repo.Path;

            //Assert
            Assert.AreEqual(defaultPath, realPath);
        }

        [TestMethod]
        public void SaveableCurrenyRepo_Saving_Load()
        {
            //Arrange
            List<ICoin> loadedCoins;

            //Act
            repo.Save();
            repo.Load();
            loadedCoins = repo.Coins;

            //Assert
            Assert.AreEqual(repo.Coins.Count, loadedCoins.Count);

            CollectionAssert.AreEqual(repo.Coins, loadedCoins);

        }
    }
}
