// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Returns Invoice Summary.
    /// </summary>
    public class InvoiceSummary
    {
        public int NumberOfRides;
        public double TotalFare;
        public double AverageFarePerRide;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">Total Number Of Rides.</param>
        /// <param name="totalFare">Total Fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.NumberOfRides = numberOfRides;
            this.TotalFare = totalFare;
            this.AverageFarePerRide = this.TotalFare / this.NumberOfRides;
        }

        /// <summary>
        /// Override equals method.
        /// </summary>
        /// <param name="obj">object of <see cref="InvoiceSummary"/>Class.</param>
        /// <returns>True If Values Are Same.</returns>
        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   this.NumberOfRides == summary.NumberOfRides &&
                   this.TotalFare == summary.TotalFare &&
                   this.AverageFarePerRide == summary.AverageFarePerRide;
        }

        /// <summary>
        /// Override HashCode Method.
        /// </summary>
        /// <returns>Return Hash Code Value.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumberOfRides, this.TotalFare, this.AverageFarePerRide);
        }
    }
}