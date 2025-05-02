using NewtonLibrary;

namespace NLES
{
    class Program
    {
        static void Main(string[] args)
        {
            Equation systemEquation1 = new Equation(-2.6e-15, -0.76, -1.6e-15, 1.6, 16, 2.76e+19, 3.26e-8, -1.6e-23, 6, 17.6);
            Equation systemEquation2 = new Equation(-9.6e-16, -0.6, -4.6e-17, 0.96, 1.6, 2.6e+20, 4.6e-9, -3.6e-23, 1, 1.05);
            Point rootsPoint = new Point(NewtonMethod.SolvingSystem(systemEquation1, systemEquation2));
            Console.WriteLine("Корни системы {0:e4}   {1:f4}", rootsPoint.x, rootsPoint.y);
            Console.ReadKey();
        }
    }
}
