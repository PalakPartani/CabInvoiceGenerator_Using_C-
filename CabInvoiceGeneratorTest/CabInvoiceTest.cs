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
            double fare = cabInvoiceGenerator.CalculateFare(4.0, 5);
            Assert.AreEqual(45.0, fare, 0.0);
        }

        /// <summary>
        /// Test For Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenMinDistanceAndTime_ShouldReturnCorrectTotalFare()
        {
            double fare = cabInvoiceGenerator.CalculateFare(0.5, 3);
            Assert.AreEqual(8, fare, 0.0);
        }

        /// <summary>
        /// Test For Calculate Fare for Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_ShouldReturnCorrectTotalFare()
        {
            Rides[] ride = { new Rides(2.0, 5), new Rides(0.1, 1) };
            InvoiceSummary invoiceSummary = cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(15.0, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test To Get Enhanced Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Rides[] rides = { new Rides(2.0, 5), new Rides(0.1, 1) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 30);
            Assert.AreEqual(summary, invoiceSummary);
        }

    }
}