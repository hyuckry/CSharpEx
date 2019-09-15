using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMethods.Library
{
    public class NumericalIntegration : INumericalIntegration
    {
        public double? ExecuteTrapezoidalMethod(Func<double, double> function, double lower, double upper, int intervals)
        {
            double stepSize = (upper - lower) / intervals;
            double? integration = function(lower) + function(upper);
            int i = 1;

            do
            {
                double k = i * stepSize;
                integration += 2 * function(k);
                i++;
            } while (i <= intervals);
            integration *= stepSize / 2;
            return integration;
        }

        public double? ExecuteSimsons13Method(Func<double, double> function, double lower, double upper, int intervals)
        {
            double stepSize = (upper - lower) / intervals;
            double? integration = function(lower) + function(upper);
            int i = 1;

            do
            {
                double k = i * stepSize;
                if (i % 2 == 0)
                {
                    integration += 2 * function(k);
                }
                else
                {
                    integration += 4 * function(k);
                }
                i++;
            } while (i <= intervals);
            integration *= stepSize / 3;
            return integration;
        }

        public double? ExecuteSimsons38Method(Func<double, double> function, double lower, double upper, int intervals)
        {
            double stepSize = (upper - lower) / intervals;
            double? integration = function(lower) + function(upper);
            int i = 1;

            do
            {
                double k = i * stepSize;
                if (i % 3 == 0)
                {
                    integration += 2 * function(k);
                }
                else
                {
                    integration += 3 * function(k);
                }
                i++;
            } while (i <= intervals);
            integration *= stepSize * 3 / 8;
            return integration;
        }

    }
}
