using System;

namespace NumericalMethods.Library
{
    public interface INumericalIntegration
    {
        double? ExecuteTrapezoidalMethod(Func<double, double> function, double lower, double upper, int intervals);
        double? ExecuteSimsons13Method(Func<double, double> function, double lower, double upper, int intervals);
        double? ExecuteSimsons38Method(Func<double, double> function, double lower, double upper, int intervals);
    }
}
