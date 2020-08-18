// <copyright file="CabInvoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// CabInvoiceGenerator to generate fare for total ride.
    /// </summary>
    public class CabInvoice
    {
        private double COSTPERMIN = 1;
        private double COSTMIN = 5;
        private double COSTPERKM = 10;
        private RideRepository rideRepository = new RideRepository();
        private RideCategory rideCategory = new RideCategory();

        public void SetValue(RideCategory rideType)
        {
            COSTPERMIN = rideType.CostPerMinute;
            COSTMIN = rideType.MinimumFare;
            COSTPERKM = rideType.CostPerKm;
        }

        /// <summary>
        /// This function is used to perform fare calculation.
        /// </summary>
        /// <param name="distance">input the distance.</param>
        /// <param name="time">input the time.</param>
        /// <returns>the fare.</returns>
        public double CalculateFare(double distance, double time, RideCategory.RideType rideType)
        {
            RideCategory ride = rideCategory.SetRideValues(rideType);
            SetValue(ride);
            double fare = (distance * COSTPERKM) + (time * COSTPERMIN);
            return Math.Max(fare, COSTMIN);
        }

        /// <summary>
        /// Calculate multiple rides.
        /// </summary>
        /// <param name="rides">Multiple ride.</param>
        /// <returns>multiple rides fare.</returns>
        public InvoiceSummary CalculateFare(Rides[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Rides ride in rides)
            {
                totalRideFare += this.CalculateFare(ride.RideDistance, ride.RideTime, ride.RideType);
            }

            return new InvoiceSummary(rides.Length, totalRideFare);
        }

        /// <summary>
        /// Adding the rides.
        /// </summary>
        /// <param name="userId">inputs the userId.</param>
        /// <param name="ride">inputs the ride array.</param>
        public void AddRides(string userId, Rides[] ride)
        {
            rideRepository.AddRide(userId, ride);
        }

        /// <summary>
        /// Calculating the invoice summary.
        /// </summary>
        /// <param name="userId">inputs the userId to determine fare.</param>
        /// <returns>invoice summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
