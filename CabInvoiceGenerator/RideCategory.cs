// <copyright file="RideCategory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
   public class RideCategory
    {
        public double MinimumFare;
        public double CostPerKm;
        public double CostPerMinute;

        public enum RideType
        {
            PREMIUM,
            NORMAL,
        }

        public RideCategory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RideCategory"/> class.
        /// </summary>
        /// <param name="costPerKm">Initialize the cost per km.</param>
        /// <param name="costPerMinute">Initialize the cost per min.</param>
        /// <param name="minimumFare">Iniitialize the minimum cost.</param>
        public RideCategory(double costPerKm, double costPerMinute, double minimumFare)
        {
            this.CostPerKm = costPerKm;
            this.CostPerMinute = costPerMinute;
            this.MinimumFare = minimumFare;
        }

        /// <summary>
        /// Setting the rides.
        /// </summary>
        /// <param name="rideTypes">input the ridetype.</param>
        /// <returns>the charges.</returns>
        public RideCategory SetRideValues(RideType rideTypes)
        {
            switch (rideTypes)
            {
                case RideType.PREMIUM:
                    return new RideCategory(15.0, 2.0, 20.0);

                case RideType.NORMAL:
                    return new RideCategory(10.0, 1.0, 5.0);

                default:
                    return null;
            }
        }
    }
}