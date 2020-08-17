// <copyright file="CabInvoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// CabInvoiceGenerator to generate fare for total ride.
    /// </summary>
    public class CabInvoice
    {
        private readonly int COSTPERMIN = 1;
        private readonly int COSTMIN = 5;
        private readonly int COSTPERKM = 10;

        /// <summary>
        /// This function is used to perform fare calculation.
        /// </summary>
        /// <param name="distance">input the distance.</param>
        /// <param name="time">input the time.</param>
        /// <returns>the fare.</returns>
        public double CalculateFare(double distance, int time)
        {
            double fare = (distance * COSTPERKM) + (time * COSTPERMIN);
            if (fare < COSTMIN)
            {
                return COSTMIN;
            }

            return fare;
        }
    }
}