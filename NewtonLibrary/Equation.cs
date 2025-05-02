namespace NewtonLibrary
{
    public class Equation
    {
        protected double _c, _k, _d, _m, _n, _q, _lambda, _l, _r, _p;
        public double C
        {
            get { return _c; }
            set { _c = value; }
        }
        public double K
        {
            get { return _k; }
            set { _k = value; }
        }
        public double D
        {
            get { return _d; }
            set { _d = value; }
        }
        public double M
        {
            get { return _m; }
            set { _m = value; }
        }
        public double N
        {
            get { return _n; }
            set { _n = value; }
        }
        public double Q
        {
            get { return _q; }
            set { _q = value; }
        }
        public double Lambda
        {
            get { return _lambda; }
            set { _lambda = value; }
        }
        public double L
        {
            get { return _l; }
            set { _l = value; }
        }
        public double R
        {
            get { return _r; }
            set { _r = value; }
        }
        public double P
        {
            get { return _p; }
            set { _p = value; }
        }
        public Equation(double c, double k, double d, double m, double n, double q, double lambda, double l, double r, double p)
        {
            _c = c; _k = k; _d = d; _m = m; _n = n; _q = q; _lambda = lambda; _l = l; _r = r; _p = p;
        }
        public double Function(Point A)
        {
            return (Math.Exp(_c * A.x) - Math.Exp(_k + _d * A.x)) * (_m + _n * A.y) - _q * (_lambda / A.x + _l) * (_r + _p * A.y);
        }
        public double DerivativeOfFunctionByX(Point A)
        {
            return (_c * Math.Exp(_c * A.x) - _d * Math.Exp(_k + _d * A.x)) * (_m + _n * A.y) + (_q * _lambda * (_r + _p * A.y)) / A.x / A.x;
        }
        public double DerivativeOfFunctionByY(Point A)
        {
            return _n * (Math.Exp(_c * A.x) - Math.Exp(_k + _d * A.x)) - _q * _p * (_lambda / A.x + _l);
        }
        public override string ToString()
        {
            return "c=" + C + "k=" + K + "d=" + D +
                "m=" + M + "n=" + N + "q=" + Q +
                "lambda=" + Lambda + "l=" + L + "r=" + R + "p=" + P;
        }

    }
}
