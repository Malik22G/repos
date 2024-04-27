using System;
namespace Matrix_nps;

public class Matix
{
    public static void Main()
    {
        Matrix M1 = new Matrix(6);

        M1.setElement(1, 2, 78);
        M1.setElement(1, 1, 23);
        Console.WriteLine(M1.getElement(1, 1));
    }
}