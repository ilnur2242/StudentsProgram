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
            //var N = Convert.ToInt32(s1[0].Split(' ')[0]);
            //var M = Convert.ToInt32(s1[0].Split(' ')[1]);
            int M, J; // column count for 1, 2 matr

            //======
            //Matrix 1
            //======
            var N = Convert.ToInt32(s1[0].Split(' ')[0]);          
            try
            {                
                M = Convert.ToInt32(s1[0].Split(' ')[1]);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("enter column count for the first matrix");//
                M = Convert.ToInt32(Console.ReadLine());
            }

            var matrix1 = new List<List<double>>();
            for (int i = 1; i <= N; i++)
            {
                matrix1.Add(new List<double>());
                foreach (var item in s1[i].Split(' '))
                {
                    matrix1.Last().Add(Convert.ToDouble(item));
                }
            }
            if (matrix1.Count * matrix1[0].Count != N * M) { Console.WriteLine("Please edit input file and restart programm"); Console.ReadLine(); Environment.Exit(0); }
            
            //======
            //Matrix 2
            //======

            var K = Convert.ToInt32(s1[N + 1].Split(' ')[0]);
            try
            {
                J =  Convert.ToInt32(s1[N + 1].Split(' ')[1]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("enter column count for the second matrix");
                J = Convert.ToInt32(Console.ReadLine());
            }
            //var J = Convert.ToInt32(s1[N + 1].Split(' ')[1]);

            var matrix2 = new List<List<double>>();
            for (int i = 1; i <= K; i++)
            {
                matrix2.Add(new List<double>());
                foreach (var item in s1[N + 1 + i].Split(' '))
                {
                    matrix2.Last().Add(Convert.ToDouble(item));
                }
            }
            if (matrix2.Count * matrix2[0].Count != K * J) { Console.WriteLine("Please edit input file and restart programm"); Console.ReadLine(); Environment.Exit(0); }
            if (M != K) { Console.WriteLine("Count of matr1's column and count of matr2's string are not equal. Please edit input file and restart programm"); Console.ReadLine(); Environment.Exit(0); }
            
            //======
            //Result matrix 
            //======
            
            var result = new List<List<double>>();
            string[] res_str = new string[N];
            for (int i = 0; i < N; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < J; j++)
                {
                    result.Last().Add(0);
                    var value = 0.0;
                    for (int _ = 0; _ < M; _++)
                    {
                        //var value1 = matrix1[i][_];
                        //var value2 = matrix2[_][j];
                        //var value = result.Last().Last();
                        //value += value1 * value2;
                        //result.Last()[result.Last().Count - 1] = value;
                        value += matrix1[i][_] * matrix2[_][j];

                    }
                    result.Last()[result.Last().Count - 1] = value;
                }
                res_str[i] = string.Join(" ", result[i].ToArray());
            }

            // Вывод результата в файл
            string path = "Out.txt";
            if (!File.Exists(path)) File.Create(path);

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < result.Count; i++)
                {                    
                        sw.WriteLine(res_str[i]);                    
                }
                sw.Close();
            }
        }
    }
}
