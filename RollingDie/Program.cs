using System;

namespace RollingDie
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingRow r = new RollingRow(Console.WriteLine, Console.WriteLine); 
            r.Roll(20);
            Console.Read();
        }
    }
}
