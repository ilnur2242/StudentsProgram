using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace StudentsProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s1 = File.ReadAllLines(args[0]);

            var matr = new Solver(s1);
            matr.Read();
            matr.Multiplication();
            matr.GiveMatrix();

        }
    }
}
