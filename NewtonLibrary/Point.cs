namespace NewtonLibrary
{
    public class Point
    {
        protected double _x, _y;
        public double x
        {
            get { return _x; }
            set { _x = value; }
        }
        public double y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Point(double X, double Y)
        {
            _x = X;
            _y = Y;
        }
        public Point(Point A)
        {
            _x = A.x;
            _y = A.y;
        }
        static public Point operator -(Point One, Point Two)
        {
            return new Point(One.x - Two.x, One.y - Two.y);
        }
        static public Point operator /(Point One, double d)
        {
            return new Point(One.x / d, One.y / d);
        }
        static public bool notMaxCriterion(Point One, Point Two)
        {
            const double e = 0.000001;
            if (Math.Max(Math.Abs(One.x - Two.x), Math.Abs(One.y - Two.y)) <= e)
                return false;
            else return true;
        }
        public override string ToString()
        {
            return string.Format(" {0:e4}   {1:f4}", this._x, this._y);
        }
    }
}