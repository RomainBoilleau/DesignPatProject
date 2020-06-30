﻿using System;

namespace ESGI.DesignPattern.Projet
{
    public class TermLoan : Loan
    {

        public TermLoan(double commitment, DateTime start)
        {
            Commitment = commitment;
            Start = start;
        }
        
        public override double Capital()
        {
            return Commitment * Duration() * RiskFactor;
        }

        public override double Duration()
        {
            var weightedAverage = 0.0;
            var sumOfPayments = 0.0;

            if (Commitment == 0)
            {
                return 0;
            }

            foreach (var payment in Payments)
            {
                sumOfPayments += payment.Amount;
                weightedAverage += YearsTo(payment.Date) * payment.Amount;
            }
            
            return weightedAverage / sumOfPayments;
        }
        
    }
}