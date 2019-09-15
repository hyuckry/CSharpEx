using System;

namespace NumericalMethods.Library
{
    public interface IOrdinaryDifferentialEquations
    {
        double[] ExecutionEulerMethod(Func<double, double, double> function,
                                      double t0,
                                      double y0,
                                      int iterations,
                                      double tEnd);
        double[] ExecutionRungeKuttaMethod(Func<double, double, double> function,
                                      double t0,
                                      double y0,
                                      int iterations,
                                      double tEnd);
    }
}
