// <copyright file="Rides.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Ride class.
    /// </summary>
    public class Rides
    {
        public double Distance;
        public double Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rides"/> class.
        /// </summary>
        /// <param name="distance">inputs distance.</param>
        /// <param name="time">inputs time.</param>
        public Rides(double distance, int time)
        {
            this.Distance = distance;
            this.Time = time;
        }
    }
}