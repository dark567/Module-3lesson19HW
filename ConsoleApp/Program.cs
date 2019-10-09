using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public delegate double DelegDictionary(double perTemp, double perTempTwo = 0);
    
    public enum MenuItem
    {
        [Description("\nSelectMenuItem:")]
        SelectMenuItem = 0,
        [Description("\t[1] Circle")]
        Circle = 1,
        [Description("\t[2] Square")]
        Square = 2,
        [Description("\t[3] Rectange")]
        Rectangle = 3,
        [Description("\t[4] Triangle")]
        Triangle = 4,
        [Description("\t[5] Exit")]
        Exit = 5
    }

    /*
     Реализовать delegate dictionary, который в зависимости от типа введенной фигуры (окружность, квадрат, прямогуольник, треугольник) 
     рассчитает площадь фигуры и длину окружности.
     */
    class Program
    {

        static void Main(string[] args)
        {
            Controller.Menu();

            Console.Read();
        }
    }

    static class Controller
    {

        public static void Menu()
        {
            bool mQuit = false;
            double area, length;
            DelegDictionary delegDictionary;

            ShowMenuItems();

            int choiceNomMenu = 0;

            while (!mQuit)
            {

                if (!Int32.TryParse(Console.ReadLine(), out choiceNomMenu) || !(choiceNomMenu >= 1 && choiceNomMenu <= 5))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t Invalid input. Try again:");
                    ShowMenuItems();
                    continue;
                }

                switch (choiceNomMenu)
                {

                    case (int)MenuItem.Circle:
                        double radios;

                        do
                        {
                            Console.Write("Input radius:");
                        } while (!double.TryParse(Console.ReadLine(), out radios));

                        delegDictionary = new DelegDictionary(Calc.GetAreaCircle);
                        area = delegDictionary(radios);
                        delegDictionary = new DelegDictionary(Calc.GetLengthCircle);
                        length = delegDictionary(radios);
                        Console.WriteLine($"Circle radios:{radios} Area:{area}");
                        Console.WriteLine($"Circle radios:{radios} Length:{length}");

                        ShowMenuItems();

                        break;
                    case (int)MenuItem.Square:
                        double Side;

                        do
                        {
                            Console.Write("Input Side:");
                        } while (!double.TryParse(Console.ReadLine(), out Side));

                        delegDictionary = new DelegDictionary(Calc.GetAreaSquare);
                        area = delegDictionary(Side);
                        delegDictionary = new DelegDictionary(Calc.GetLengthSquare);
                        length = delegDictionary(Side);
                        Console.WriteLine($"Square side:{Side} Area:{area}");
                        Console.WriteLine($"Square side:{Side} Length:{length}");


                        ShowMenuItems();
                        break;
                    case (int)MenuItem.Rectangle:
                        double SideOne, SideTwo;

                        do
                        {
                            Console.Write("Input Side One:");
                        } while (!double.TryParse(Console.ReadLine(), out SideOne));

                        do
                        {
                            Console.Write("Input Side Two:");
                        } while (!double.TryParse(Console.ReadLine(), out SideTwo));

                        delegDictionary = new DelegDictionary(Calc.GetAreaRectangle);
                        area = delegDictionary(SideOne, SideTwo);
                        delegDictionary = new DelegDictionary(Calc.GetLengthRectangle);
                        length = delegDictionary(SideOne, SideTwo);
                        Console.WriteLine($"Rectangle sideOne:{SideOne},sideTwo:{SideTwo} Area:{area}");
                        Console.WriteLine($"Rectangle sideOne:{SideOne},sideTwo:{SideTwo} Length:{length}");

                        ShowMenuItems();
                        break;
                    case (int)MenuItem.Triangle:
                        double Hight, Base;

                        do
                        {
                            Console.Write("Input Hight:");
                        } while (!double.TryParse(Console.ReadLine(), out Hight));

                        do
                        {
                            Console.Write("Input base side:");
                        } while (!double.TryParse(Console.ReadLine(), out Base));

                        delegDictionary = new DelegDictionary(Calc.GetAreaTriangle);
                        area = delegDictionary(Hight, Base);
                        delegDictionary = new DelegDictionary(Calc.GetLengthTriangle);
                        length = delegDictionary(Hight, Base);
                        Console.WriteLine($"Triangle hight:{Hight},base side:{Base} Area:{area}");
                        Console.WriteLine($"Triangle hight:{Hight},base side:{Base} Length:{length}");

                        ShowMenuItems();
                        break;
                    case (int)MenuItem.Exit:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\t Quitting...");
                        mQuit = true;
                        break;
                    default:
                        break;
                }

            }
        }

        /// <summary>
        /// Get Description Enum
        /// </summary>
        /// <param name="value">Enum type</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var descriptionAttribute = (DescriptionAttribute)value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(a => a is DescriptionAttribute)
                .FirstOrDefault();

            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }

        /// <summary>
        /// Show menu items
        /// </summary>
        public static void ShowMenuItems()
        {
            foreach (MenuItem item in Enum.GetValues(typeof(MenuItem)))
            {
                if (item == 0) Console.ForegroundColor = ConsoleColor.DarkYellow;
                else Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item.GetDescription());
            }
        }

    }
}
