using System;

class Program
{
    static void Main(string[] args)
    {
       Fraction f1= new Fraction();
       Console.WriteLine(f1.GetFractionString());
       Console.WriteLine(f1.GetDecimalValue());
       
       Fraction f2= new Fraction(6);
       Console.WriteLine(f2.GetFractionString());
       Console.WriteLine(f2.GetDecimalValue());

       Fraction f3= new Fraction(4, 5);
       Console.WriteLine(f3.GetFractionString());
       Console.WriteLine(f3.GetDecimalValue());

       Fraction f4= new Fraction(25, 100);
       Console.WriteLine(f4.GetFractionString());
       Console.WriteLine(f4.GetDecimalValue());

       Random randomNum= new Random();
       Fraction f5= new Fraction();
       for(int i= 0; i< 20; i++)
        {
            int topValue = randomNum.Next(1, 11);
            int bottomValue = randomNum.Next(1, 11);
            f5.SetTopNum(topValue);
            f5.SetBottomNum(bottomValue);
            Console.Write($"Fraction #{i + 1}: ");
            Console.Write($"string: {f5.GetFractionString()}");
            Console.WriteLine($" Number: {f5.GetDecimalValue()}");
        }
    }
}