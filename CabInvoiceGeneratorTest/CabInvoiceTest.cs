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
            Rides[] ride = { new Rides(2.0, 5, RideCategory.RideType.NORMAL), new Rides(0.1, 1, RideCategory.RideType.NORMAL) };
            InvoiceSummary invoiceSummary = cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(15.0, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test To Get Enhanced Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Rides[] rides = { new Rides(2.0, 5, RideCategory.RideType.NORMAL), new Rides(0.1, 1, RideCategory.RideType.NORMAL) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 30);
            Assert.AreEqual(summary, invoiceSummary);
        }

        /// <summary>
        /// Test cab invoice from userId.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            string userId = "plk@ggg.com";
            Rides[] ride = { new Rides(2.0, 5, RideCategory.RideType.NORMAL), new Rides(0.1, 1, RideCategory.RideType.NORMAL) };
            cabInvoiceGenerator.AddRides(userId, ride);
            InvoiceSummary invoiceSummary = cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedInvoiceSummary, invoiceSummary);
        }

        /// <summary>
        /// Test premium rides without userId.
        /// </summary>
        [Test]
        public void GivenUserIdAndPremiumRides_ShouldReturnInvoiceSummary()
        {
            Rides[] rides = { new Rides(2.0, 5, RideCategory.RideType.PREMIUM), new Rides(0.1, 1, RideCategory.RideType.PREMIUM) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 30);
            Assert.AreEqual(summary, invoiceSummary);
        }

        /// <summary>
        /// Test for multiple prenium and normal rides.
        /// </summary>
        [Test]
        public void GivenUserIdAndNormalAndPremiumRides_ShouldReturnInvoiceSummary()
        {
            string userId = "plk@ggg.com";
            Rides[] rides =
            {
                new Rides(2.0, 5, RideCategory.RideType.NORMAL),
                new Rides(2.0, 5, RideCategory.RideType.PREMIUM),
            };
            cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary summary = cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Test for multiple premium rides.
        /// </summary>
        [Test]
        public void GivenUserIdAndMultiplePremiumRides_ShouldReturnInvoiceSummary()
        {
            string userId = "plk@ggg.com";
            Rides[] rides =
            {
                new Rides(2.0, 5, RideCategory.RideType.PREMIUM),
                new Rides(2.0, 5, RideCategory.RideType.PREMIUM),
            };
            cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary summary = cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}