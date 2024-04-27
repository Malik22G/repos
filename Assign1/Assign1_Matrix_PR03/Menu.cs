using System;

namespace Matrix_nps
{
    internal class Menu
    {
        private Matrix M1, M2;

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome! Please select an option:");
                Console.WriteLine("1: Create a new Matrix M1.");
                Console.WriteLine("2: Create a new Matrix M2.");
                Console.WriteLine("3: Set an element in M1.");
                Console.WriteLine("4: Set an element in M2.");
                Console.WriteLine("5: Add M1 and M2.");
                Console.WriteLine("6: Multiply M1 by M2.");
                Console.WriteLine("7: Print M1.");
                Console.WriteLine("8: Print M2.");
                Console.WriteLine("9: Exit.");

                int optionSelected = int.Parse(Console.ReadLine());
                if (optionSelected < 1 || optionSelected > 9)
                {
                    Console.WriteLine("Please select a valid option.");
                    continue;
                }

                switch (optionSelected)
                {
                    case 1:
                        M1 = CreateMatrix();
                        break;
                    case 2:
                        M2 = CreateMatrix();
                        break;
                    case 3:
                        SetMatrixElement(M1);
                        break;
                    case 4:
                        SetMatrixElement(M2);
                        break;
                    case 5:
                        if (M1 == null || M2 == null)
                        {
                            Console.WriteLine("Please create both matrices first.");
                            break;
                        }
                        try
                        {
                            Matrix sum = M1 + M2;
                            Console.WriteLine("Result of M1 + M2:");
                            sum.Print();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 6:
                        if (M1 == null || M2 == null)
                        {
                            Console.WriteLine("Please create both matrices first.");
                            break;
                        }
                        try
                        {
                            Matrix result = M1 * M2;
                            Console.WriteLine("Result of M1 * M2:");
                            result.Print();
                        }
                        catch(Exception e) {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 7:
                        if (M1 == null)
                        {
                            Console.WriteLine("M1 is not created yet.");
                            break;
                        }
                        Console.WriteLine("Matrix M1:");
                        M1.Print();
                        break;
                    case 8:
                        if (M2 == null)
                        {
                            Console.WriteLine("M2 is not created yet.");
                            break;
                        }
                        Console.WriteLine("Matrix M2:");
                        M2.Print();
                        break;
                    case 9:
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please select again.");
                        break;
                }
            }
        }

        private Matrix CreateMatrix()
        {
            try
            {
                Console.Write("Enter size of the matrix: ");
                int size = int.Parse(Console.ReadLine());
                Matrix M = new Matrix(size);
                Console.WriteLine("Matrix created successfully.");
                return M;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new Matrix(0);
        }

        private void SetMatrixElement(Matrix matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix is not created yet.");
                return;
            }

            Console.Write("Enter row: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Enter column: ");
            int j = int.Parse(Console.ReadLine());
            Console.Write("Enter value: ");
            int value = int.Parse(Console.ReadLine());
            try
            {
                matrix.setElement(i, j, value);
                Console.WriteLine("Element set successfully.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}