using System;

namespace RepositoryExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu.MenuBody();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

    }
}
