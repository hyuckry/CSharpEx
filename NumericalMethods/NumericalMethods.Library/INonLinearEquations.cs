using System;

namespace NumericalMethods.Library
{
    interface INonLinearEquations
    {
        double? ExecuteBisectionMethod(Func<double, double> function, double lower, double upper, double error);
        double? ExecuteRegularFalsiMethod(Func<double, double> function, double lower, double upper, double error);
        double? ExecuteSecantiMethod(Func<double, double> function,
                                     double lower,
                                     double upper,
                                     double error,
                                     int iterations);
        double? ExecuteNewtonRaphsonMethod(Func<double, double> function,
                                           Func<double, double> derivative,
                                           double initialGuess,
                                           double error,
                                           int iterations);
    }
}
