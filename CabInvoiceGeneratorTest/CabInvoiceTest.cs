// <copyright file="CabInvoiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    public class CabInvoiceTest
    {
        private CabInvoice cabInvoiceGenerator;

        /// <summary>
        /// Ititialize CabInvoiceGenerator class.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoice();
        }

        /// <summary>
        /// Calculate total fare through distance and time.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnCorrectTotalFare()
        {
            double fare = cabInvoiceGenerator.CalculateFare(2.0, 5);
            Assert.AreEqual(25, fare, 0.0);
        }
    }
}