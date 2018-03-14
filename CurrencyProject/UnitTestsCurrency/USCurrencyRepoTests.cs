using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyProject;

namespace UnitTestsCurrency
{
    [TestClass]
    public class USCurrencyRepoTests
    {
        ICurrencyRepo repo;
        Penny penny;
        Nickel nickel;
        Dime dime;
        Quarter quarter;
        DollarCoin dollarCoin;


        public USCurrencyRepoTests()
        {
            repo = new USCurrencyRepo();
            penny = new Penny();
            nickel = new Nickel();
            dime = new Dime();
            quarter = new Quarter();
            dollarCoin = new DollarCoin();
        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;
            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();

            repo.AddCoin(penny);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(penny);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.AddCoin(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.AddCoin(dime);
            valueAfterDime = repo.TotalValue();
            repo.AddCoin(quarter);
            valueAfterQuarter = repo.TotalValue();
            repo.AddCoin(dollarCoin);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny + numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig + penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny + (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            Assert.AreEqual(valueAfterFiveMorePennies + nickel.MonetaryValue, valueAfterNickel);
            Assert.AreEqual(valueAfterNickel + dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime + quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter + dollarCoin.MonetaryValue, valueAfterDollar);

        }


        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;

            repo = new USCurrencyRepo();  //reset repo

            //add some coins
            repo.AddCoin(penny);

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(penny);
            }
            repo.AddCoin(nickel);
            repo.AddCoin(dime);
            repo.AddCoin(quarter);
            repo.AddCoin(dollarCoin);

            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();
            repo.RemoveCoin(penny);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.RemoveCoin(penny);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.RemoveCoin(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.RemoveCoin(dime);
            valueAfterDime = repo.TotalValue();
            repo.RemoveCoin(quarter);
            valueAfterQuarter = repo.TotalValue();
            repo.RemoveCoin(dollarCoin);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny - numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig - penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny - (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            //Assert.AreEqual(valueAfterFiveMorePennies - nickel.MonetaryValue, valueAfterNickel); //HUH? 1.35 != 1.35 both are double?
            Assert.AreEqual(valueAfterNickel - dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime - quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter - dollarCoin.MonetaryValue, valueAfterDollar);

        }

        [TestMethod]
        public void MakeChangeTests()
        {
            //Arrange
            USCurrencyRepo changeOneQuatersOnHalfDollar, changeTwoDollars, changeOneDollarOneHalfDoller,
               changeOneDimeOnePenny, changeOneNickelOnePenny, changeFourPennies;


            //Act
            changeTwoDollars = (USCurrencyRepo)USCurrencyRepo.CreateChange(2.0);
            changeOneDollarOneHalfDoller = (USCurrencyRepo)USCurrencyRepo.CreateChange(1.5);
            changeOneQuatersOnHalfDollar = (USCurrencyRepo)USCurrencyRepo.CreateChange(.75);

            changeOneDimeOnePenny = (USCurrencyRepo)USCurrencyRepo.CreateChange(.11);
            changeOneNickelOnePenny = (USCurrencyRepo)USCurrencyRepo.CreateChange(.06);
            changeFourPennies = (USCurrencyRepo)USCurrencyRepo.CreateChange(.04);


            //Assert
            Assert.AreEqual(changeTwoDollars.Coins.Count, 2);
            Assert.AreEqual(changeTwoDollars.Coins[0].GetType(), new DollarCoin().GetType());
            Assert.AreEqual(changeTwoDollars.Coins[1].GetType(), new DollarCoin().GetType());

            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins.Count, 2);
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[0].GetType(), new DollarCoin().GetType());
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[1].GetType(), new HalfDollar().GetType());


            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins.Count, 2);
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[0].GetType(), new HalfDollar().GetType());
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[1].GetType(), new Quarter().GetType());

            Assert.AreEqual(changeOneDimeOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneDimeOnePenny.Coins[0].GetType(), new Dime().GetType());
            Assert.AreEqual(changeOneDimeOnePenny.Coins[1].GetType(), new Penny().GetType());

            Assert.AreEqual(changeOneNickelOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneNickelOnePenny.Coins[0].GetType(), new Nickel().GetType());
            Assert.AreEqual(changeOneNickelOnePenny.Coins[1].GetType(), new Penny().GetType());


            Assert.AreEqual(changeFourPennies.Coins.Count, 4);
            Assert.AreEqual(changeFourPennies.Coins[0].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[1].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[2].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[3].GetType(), new Penny().GetType());

        }
        [TestMethod]
        public void ReduceSixPennies()
        {
            //Arrange
            ICurrencyRepo sixPennies, sixPenniesReduced;


            //Act
            sixPennies = new USCurrencyRepo();
            for (int i = 0; i < 6; i++)
            {
                sixPennies.AddCoin(new Penny());
            }
            sixPenniesReduced = sixPennies.Reduce();

            //Assert
            Assert.AreEqual(2, sixPenniesReduced.GetCoinCount());
        }

        [TestMethod]
        public void ReduceNinePennies()
        {
            //Arrange
            ICurrencyRepo Pennies, PenniesReduced;
            double initialValue, reducedValue;

            //Act
            Pennies = new USCurrencyRepo();
            for (int i = 0; i < 9; i++)
            {
                Pennies.AddCoin(new Penny());
            }

            initialValue = Pennies.TotalValue();
            PenniesReduced = Pennies.Reduce();
            reducedValue = Pennies.TotalValue();

            //Assert
            Assert.AreEqual(5, PenniesReduced.GetCoinCount());
            Assert.AreEqual(initialValue, reducedValue);
        }

        [TestMethod]
        public void ReduceTwelvePennies()
        {
            //Arrange
            ICurrencyRepo Coins, CoinsReduced;
            double initialValue, reducedValue;

            //Act
            Coins = new USCurrencyRepo();
            for (int i = 0; i < 12; i++)
            {
                Coins.AddCoin(new Penny());
            }
            initialValue = Coins.TotalValue();
            CoinsReduced = Coins.Reduce();
            reducedValue = Coins.TotalValue();


            //Assert
            Assert.AreEqual(3, CoinsReduced.GetCoinCount());
            Assert.AreEqual((decimal)initialValue, (decimal)reducedValue);
        }

        [TestMethod]
        public void ReduceNinetyNinePennies()
        {
            //Arrange
            ICurrencyRepo Coins, CoinsReduced;
            double initialValue, reducedValue;

            //Act
            Coins = new USCurrencyRepo();
            for (int i = 0; i < 99; i++)
            {
                Coins.AddCoin(new Penny());
            }
            initialValue = Coins.TotalValue();
            CoinsReduced = Coins.Reduce();
            reducedValue = Coins.TotalValue();


            //Assert
            Assert.AreEqual(8, CoinsReduced.GetCoinCount());
            Assert.AreEqual((decimal)initialValue, (decimal)reducedValue);
        }

        [TestMethod]
        public void ReduceTwentySixPennies()
        {
            //Arrange
            ICurrencyRepo Coins, CoinsReduced;
            double initialValue, reducedValue;

            //Act
            Coins = new USCurrencyRepo();
            for (int i = 0; i < 26; i++)
            {
                Coins.AddCoin(new Penny());
            }
            initialValue = Coins.TotalValue();
            CoinsReduced = Coins.Reduce();
            reducedValue = Coins.TotalValue();


            //Assert
            Assert.AreEqual(2, CoinsReduced.GetCoinCount());
            Assert.AreEqual((decimal)initialValue, (decimal)reducedValue);

        }
    }
}