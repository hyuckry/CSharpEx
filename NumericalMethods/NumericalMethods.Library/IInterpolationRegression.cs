namespace NumericalMethods.Library
{
    public interface IInterpolationRegression
    {
        double? ExecuteLinearInterpolation(double x0,
                                           double y0,
                                           double x1,
                                           double y1,
                                           double xp);
        /// <summary>
        /// y=a+bx
        /// </summary>
        /// <param name="xValues"></param>
        /// <param name="yValues"></param>
        /// <returns></returns>
        double[] ExecuteLinearRegression(double[] xValues, double[] yValues);
        /// <summary>
        /// y=ax^b
        /// </summary>
        /// <param name="xValues"></param>
        /// <param name="yValues"></param>
        /// <returns></returns>
        double[] ExecutePowerRegression(double[] xValues, double[] yValues);
    }
}
