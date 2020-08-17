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
        private readonly int COSTPERMIN = 1;
        private readonly int COSTMIN = 5;
        private readonly int COSTPERKM = 10;
        private RideRepository rideRepository = new RideRepository();

        /// <summary>
        /// This function is used to perform fare calculation.
        /// </summary>
        /// <param name="distance">input the distance.</param>
        /// <param name="time">input the time.</param>
        /// <returns>the fare.</returns>
        public double CalculateFare(double distance, double time)
        {
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
                totalRideFare += this.CalculateFare(ride.RideDistance, ride.RideTime);
            }

            return new InvoiceSummary(rides.Length, totalRideFare);
        }

        public void AddRides(string userId, Rides[] ride)
        {
            rideRepository.AddRide(userId, ride);
        }

        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
