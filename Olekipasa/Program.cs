using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App5
{
    class Program
    {
        static void Main()
        {
            Onedimensional<int> IntOne = new Onedimensional<int>();
            Onedimensional<string> StringOne = new Onedimensional<string>();

            //int-÷àñòü:
            for(int i = 0; i < 9; i++)
            {
                IntOne.Add(i + 1);
            }
            int intitem = int.Parse(Console.ReadLine());
            IntOne.Remove(intitem, (y, x) => y == x);
            IntOne.ByCondition((x) => x < 5);
            IntOne.Reverse();
            IntOne.ActionForAll((x) => x * x * x);
            Console.WriteLine(IntOne.ConditionForOne((x) => x <= 5));
            Console.WriteLine(IntOne.ConditionForAll((x) => x <= 5));
            Console.WriteLine(IntOne.Size());
            Console.WriteLine(IntOne.AmountByCondition((x) => x <= 5));
            IntOne.Print();
            Console.WriteLine("Минимум массива:" + IntOne.Min());
            Console.WriteLine("Максимум массива:" + IntOne.Max());


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            //string-÷àñòü:
            for (int i = 0; i < 9; i++)
            {
                StringOne.Add($"{i + 1}");
            }
            string stringitem = Console.ReadLine();
            StringOne.Remove(stringitem, (y, x) => y == x);
            StringOne.ByCondition((x) => x != "èñêëþ÷åíèÿ äîâîäÿò äî ñàìîóáèéñòâà");
            StringOne.Reverse();
            StringOne.ActionForAll((x) => x + x);
            Console.WriteLine(StringOne.ConditionForOne((x) => x != "5"));
            Console.WriteLine(StringOne.ConditionForAll((x) => x != "5"));
            Console.WriteLine(StringOne.Size());
            Console.WriteLine(StringOne.AmountByCondition((x) => x != "5"));
            StringOne.Print();
            Console.WriteLine("Минимум массива:" + StringOne.Min());
            Console.WriteLine("Максимум массива:" + StringOne.Max());
        }
    }
}
