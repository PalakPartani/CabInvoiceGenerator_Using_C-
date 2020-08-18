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
        private double  DistanceForRideOne = 4.0;
        private double TimeForRideOne = 5;
        private double DistanceForRideTwo = 2.0;
        private double TimeForRideTwo = 5;
        private double MinDistance = 0.1;
        private double MinTime = 3;

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
            double fare = cabInvoiceGenerator.CalculateFare(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.NORMAL);
            Assert.AreEqual(45.0, fare, 0.0);
        }

        /// <summary>
        /// Test For Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenMinDistanceAndTime_ShouldReturnCorrectTotalFare()
        {
            double fare = cabInvoiceGenerator.CalculateFare(MinDistance, MinTime,  RideCategory.RideType.NORMAL);
            Assert.AreEqual(5.0, fare, 0.0);
        }

        /// <summary>
        /// Test For Calculate Fare for Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_ShouldReturnCorrectTotalFare()
        {
            Rides[] ride = { new Rides(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.NORMAL), new Rides(DistanceForRideTwo, TimeForRideTwo, RideCategory.RideType.NORMAL) };
            InvoiceSummary invoiceSummary = cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(35.0, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test To Get Enhanced Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Rides[] rides = { new Rides(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.NORMAL), new Rides(DistanceForRideTwo, TimeForRideTwo, RideCategory.RideType.NORMAL) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 70);
            Assert.AreEqual(summary.TotalFare, invoiceSummary.TotalFare);
        }

        /// <summary>
        /// Test cab invoice from userId.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            string userId = "plk@ggg.com";
            Rides[] ride = { new Rides(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.NORMAL), new Rides(DistanceForRideTwo, TimeForRideTwo, RideCategory.RideType.NORMAL) };
            cabInvoiceGenerator.AddRides(userId, ride);
            InvoiceSummary invoiceSummary = cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 70.0);
            Assert.AreEqual(expectedInvoiceSummary.TotalFare, invoiceSummary.TotalFare);
        }

        /// <summary>
        /// Test premium rides without userId.
        /// </summary>
        [Test]
        public void GivenUserIdAndPremiumRides_ShouldReturnInvoiceSummary()
        {
            Rides[] rides =
            {
                new Rides(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.PREMIUM),
                new Rides(DistanceForRideTwo, TimeForRideTwo, RideCategory.RideType.PREMIUM),
            };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 110.0);
            Assert.AreEqual(summary.TotalFare, invoiceSummary.TotalFare);
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
                new Rides(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.NORMAL),
                new Rides(DistanceForRideTwo, TimeForRideTwo, RideCategory.RideType.PREMIUM),
            };
            cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary summary = cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 85.0);
            Assert.AreEqual(expectedInvoiceSummary.TotalFare, summary.TotalFare);
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
                new Rides(DistanceForRideOne, TimeForRideOne, RideCategory.RideType.PREMIUM),
                new Rides(DistanceForRideTwo, TimeForRideTwo, RideCategory.RideType.PREMIUM),
            };
            cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary summary = cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 110.0);
            Assert.AreEqual(expectedInvoiceSummary.TotalFare, summary.TotalFare);
        }
    }
}