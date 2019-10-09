using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Calc
    {

        // длина окружности
        public static double GetLengthCircle(double r, double b)
        {
            double length;
            length = 2 * Math.PI * r;
            return length;
        }

        // площадь круга
        public static double GetAreaCircle(double r, double b)
        {
            double area;
            area = Math.PI * r * r;
            return area;
        }

        // длина квадрата
        public static double GetLengthSquare(double r, double b)
        {
            return 4 * r;
        }

        // площадь квадрата
        public static double GetAreaSquare(double r, double b)
        {
            return Math.Pow(r, 2);
        }

        // длина прямоугольника
        public static double GetLengthRectangle(double a, double b)
        {
            return 2 * a + 2 * b;
        }

        // площадь прямоугольника
        public static double GetAreaRectangle(double a, double b)
        {
            return a * b;
        }

        // длина треугольника
        public static double GetLengthTriangle(double a, double b)
        {
            return 2*a + b;
        }

        // площадь треугольника
        public static double GetAreaTriangle(double a, double h)
        {
            return (a*h)/2;
        }
    }
}
