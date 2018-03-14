using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyProject;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnitTestsCurrency
{
    [TestClass]
    public class USCoinTests
    {

        Penny p;

        public USCoinTests()
        {
            p = new Penny();
        }


        [TestMethod]
        public void USCoinPennyConstructor()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual(CurrencyProject.USCoinMintMark.D, p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current year is default year

        }

        [TestMethod]
        public void USCoinMintMark()
        {

            //Arrange
            string mintNameDenver, mintNamePhili, mintNameSanFran, mintNameWestPoint;
            USCoinMintMark D, P, S, W;

            //Act 
            mintNameDenver = "Denver";
            mintNamePhili = "Philadephia";
            mintNameSanFran = "San Francisco";
            mintNameWestPoint = "West Point";
            D = CurrencyProject.USCoinMintMark.D;
            P = CurrencyProject.USCoinMintMark.P;
            S = CurrencyProject.USCoinMintMark.S;
            W = CurrencyProject.USCoinMintMark.W;

            //Assert
            Assert.AreEqual(USCoin.GetMintNameFromMark(D), mintNameDenver);
            Assert.AreEqual(USCoin.GetMintNameFromMark(P), mintNamePhili);
            Assert.AreEqual(USCoin.GetMintNameFromMark(S), mintNameSanFran);
            Assert.AreEqual(USCoin.GetMintNameFromMark(W), mintNameWestPoint);
        }

        [TestMethod]
        public void USCoinPennyMonetaryValue()
        {
            //Arrange
            p = new Penny();
            //Act 
            //nothing should have .01;
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void USCoinPennyAbout()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual("US Penny is from 2017. It is worth $0.01. It was made in Denver", p.About());
        }

        [TestMethod]
        public void USCoinSerialize()
        {
            //Arrange
            List<ICoin> coinList, readCoinList;
            coinList = getCoinList();
            //Act 

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, coinList);
            stream.Position = 0;
            readCoinList = (List<ICoin>)formatter.Deserialize(stream);
            //Assert
            foreach (Coin c in coinList)
            {
                Assert.IsTrue(c is ISerializable);
            }
            CollectionAssert.AreEqual(coinList, readCoinList);

        }

        private List<ICoin> getCoinList()
        {
            ICoin n = new Nickel();
            ICoin pen = new Penny();
            ICoin q = new Quarter();
            ICoin d = new Dime();
            ICoin hd = new HalfDollar();
            ICoin doll = new DollarCoin();

            List<ICoin> coinList = new List<ICoin>
            {
                { doll },
                { hd },
                { q },
                { d },
                { n },
                { pen }
            };
            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();

        }
    }
}
