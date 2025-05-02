namespace NewtonLibrary
{
    public class NewtonMethod
    {
        static public Point SolvingSystem(Equation equationOne, Equation equationTwo)
        {
            int i = 1;
            Random rnd = new Random();
            Point startingPoint = new Point(Math.Round(rnd.NextDouble() + rnd.Next(0, 1), 3), Math.Round(rnd.NextDouble() + rnd.Next(0, 1), 3));
            double detJacobian = equationOne.DerivativeOfFunctionByX(startingPoint) * equationTwo.DerivativeOfFunctionByY(startingPoint);
            detJacobian -= equationOne.DerivativeOfFunctionByY(startingPoint) * equationTwo.DerivativeOfFunctionByX(startingPoint);
            Point deltaPoint = new Point(equationOne.Function(startingPoint) * equationTwo.DerivativeOfFunctionByY(startingPoint) - equationTwo.Function(startingPoint) * equationOne.DerivativeOfFunctionByY(startingPoint),
               equationTwo.Function(startingPoint) * equationOne.DerivativeOfFunctionByX(startingPoint) - equationOne.Function(startingPoint) * equationTwo.DerivativeOfFunctionByX(startingPoint));
            deltaPoint /= detJacobian;
            Point nextPoint = new Point(startingPoint - deltaPoint);
            Console.WriteLine("Точка старта : " + startingPoint);
            Console.WriteLine("{0}-точка траектории : " + nextPoint, i);
            while (Point.notMaxCriterion(startingPoint, nextPoint))
            {
                startingPoint = new Point(nextPoint);
                detJacobian = equationOne.DerivativeOfFunctionByX(startingPoint) * equationTwo.DerivativeOfFunctionByY(startingPoint);
                detJacobian -= equationOne.DerivativeOfFunctionByY(startingPoint) * equationTwo.DerivativeOfFunctionByX(startingPoint);
                deltaPoint = new Point(equationOne.Function(startingPoint) * equationTwo.DerivativeOfFunctionByY(startingPoint) - equationTwo.Function(startingPoint) * equationOne.DerivativeOfFunctionByY(startingPoint),
                   equationTwo.Function(startingPoint) * equationOne.DerivativeOfFunctionByX(startingPoint) - equationOne.Function(startingPoint) * equationTwo.DerivativeOfFunctionByX(startingPoint));
                deltaPoint /= detJacobian;
                nextPoint = new Point(startingPoint - deltaPoint);
                if (nextPoint.x < 0) { nextPoint = new Point(startingPoint); break; }
                if (nextPoint.y < 0 || nextPoint.y > 1) { nextPoint = new Point(startingPoint); break; }
                Console.WriteLine("{0}-точка траектории : " + nextPoint, ++i);
            }
            Console.WriteLine(); return nextPoint;
        }
    }
}
