﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMethods.Library
{
    public class OrdinaryDifferentialEquations : IOrdinaryDifferentialEquations
    {
        public double[] ExecutionEulerMethod(Func<double, double, double> f, double t0, double y0, int n, double tn)
        {
            double h = (tn - t0) / n;
            int i = 0;
            double yn = 0;

            double[] results = new double[n + 1];
            results[0] = y0;

            do
            {
                yn = y0 + h * f(t0 + i * h, y0);
                y0 = yn;
                i++;
                results[i] = yn;

            } while (i < n);
            return results;
        }

        public double[] ExecutionRungeKuttaMethod(Func<double, double, double> f, double t0, double y0, int n, double tn)
        {
            double h = (tn - t0) / n;
            int i = 0;
            double yn = 0;

            double[] results = new double[n + 1];
            results[0] = y0;

            do
            {
                double k1 = h * f(t0, y0);
                double k2 = h * f(t0 + h / 2, y0 + k1 / 2);
                double k3 = h * f(t0 + h / 2, y0 + k2 / 2);
                double k4 = h * f(t0 + h , y0 + k3);
                double k = (k1 + 2 * k2 + 2 * k3 + k4) / 6;                
                yn = y0 + k;                
                i++;
                t0 += h;
                y0 = yn;
                results[i] = yn;
            } while (i < n);
            return results;
        }
    }
}
