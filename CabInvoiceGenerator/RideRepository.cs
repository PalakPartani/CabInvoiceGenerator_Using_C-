// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to add rides.
    /// </summary>
    public class RideRepository
    {
        private Dictionary<string, List<Rides>> RideList = new Dictionary<string, List<Rides>>();

        /// <summary>
        /// Add rides.
        /// </summary>
        /// <param name="userId">userId as input string.</param>
        /// <param name="rides">rides array as an input.</param>
        public void AddRide(string userId, Rides[] rides)
        {
            if (!RideList.ContainsKey(userId))
            {
                this.RideList.Add(userId, new List<Rides>(rides));
            }
        }

        /// <summary>
        /// get the ride.
        /// </summary>
        /// <param name="userId">input userid.</param>
        /// <returns>array of rides.</returns>
        public Rides[] GetRides(string userId)
        {
            return this.RideList[userId].ToArray();
        }
    }
}