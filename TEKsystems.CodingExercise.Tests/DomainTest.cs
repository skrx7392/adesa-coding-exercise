using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TEKsystems.CodingExercise.Console.Domain.Product;
using TEKsystems.CodingExercise.Console.Utility;

namespace TEKsystems.CodingExercise.Tests
{
    [TestClass]
    public class DomainTest
    {
        [TestMethod]
        public void ShouldCalculateTaxOnMusic()
        {
            var musicCd = new Music { Id = 2, Name = "music CD", Price = 14.99m };

            Assert.AreEqual( 1.5m, Taxes.ComputeSalesTax( musicCd ) );
        }

        [TestMethod]
        public void ShouldCalculateTaxOnImportedChocolates()
        {
            var chocolates = new Food { Id = 4, Name = "chocolates", Price = 10.0m, IsImported = true };

            Assert.AreEqual( Taxes.ComputeSalesTax( chocolates ), 0.5m );
        }

        [TestMethod]
        public void ShouldCalculateTaxOnPerfume()
        {
            var perfume = new Perfume { Id = 5, Name = "perfume", Price = 47.5m, IsImported = true };
            
            Assert.AreEqual( Taxes.ComputeSalesTax( perfume ), 7.15m );
        }

        [TestMethod]
        public void ShouldCalculateTaxOnPerfume2()
        {
            var perfume = new Perfume { Id = 6, Name = "perfume", Price = 27.99m, IsImported = true };

            Assert.AreEqual( Taxes.ComputeSalesTax( perfume ), 4.2m );
        }
    }
}
