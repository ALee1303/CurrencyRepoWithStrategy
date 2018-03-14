using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyProject;

namespace UnitTestsCurrency
{
    [TestClass]
    public class NickelTests
    {

        [TestMethod]
        public void NickelConstructor()
        {
            //Arrange
            Nickel p, philiNickel;
            //Act 
            p = new Nickel();
            philiNickel = new Nickel(USCoinMintMark.P);
            //Assert
            Assert.AreEqual(USCoinMintMark.D, p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current Year is default year

            Assert.AreEqual(USCoinMintMark.P, philiNickel.MintMark);

        }

        [TestMethod]
        public void NickelMonetaryValue()
        {
            //Arrange
            Nickel p;
            //Act 
            p = new Nickel();
            //Assert
            Assert.AreEqual(.05, p.MonetaryValue);
        }

        [TestMethod]
        public void NickelAbout()
        {
            //Arrange
            Nickel p;
            //Act 
            p = new Nickel();
            //Assert
            Assert.AreEqual("US Nickel is from 2017. It is worth $0.05. It was made in Denver", p.About());
        }
    }
}
