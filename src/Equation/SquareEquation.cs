namespace Equation
{
    public class SquareEquation
    {
        public double[] Solve(double a, double b, double c)
        {
            if (double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c)
                || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
            {
                throw new ArgumentException("Do not work with NaN and Infinity coefficients");
            }

            if (Math.Abs(a) < Double.Epsilon)
            {
                throw new ArgumentException("Coefficient a must not be equal zero");
            }

            var D = b * b - 4 * a * c;

            //если дискрименант отрицательный
            if (D < -Double.Epsilon)
            {
                return new double[] { };
            }
            //если дискрименант равен 0
            if (Math.Abs(D) <= Double.Epsilon)
            {
                var x = -b / (2 * a);
                return new double[] { x, x };
            }
            //если дискрименант положительный
            if (D > Double.Epsilon)
            {
                var x1 = -b + Math.Sqrt(D) / (2 * a);
                var x2 = -b - Math.Sqrt(D) / (2 * a);
                return new double[] { x1, x2 };
            }

            throw new ArgumentException();
        }
    }
}