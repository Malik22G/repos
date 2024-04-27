
using System.Data.Common;

namespace Matrix_nps
{
    public class Matrix : Exception
    {
        private List<int> vec;
        private readonly int size;

        public Matrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException ("Matrix size must be greater than 0.");
            }

            this.size = size;
            vec = new List<int>();

            for(int i=0;i< (3*size - 2); i++)
            {
                vec.Add(0);
            }


        }

        private int Index(int i, int j)
        {
            if(i<1 || j<1 || j>size || i > size)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (j == 1)
            {
                return (i - 1);
            }
            if (j == size)
            {
                return size + i - 1;
            }
            if (i == j)
            {
                return 2 * size + i - 2;
            }

            return -1;
        }
        public int getElement(int i, int j)
        {
            int index = Index(i, j);
            if (index == -1) return 0;
            return this.vec[index];
        }

        public void setElement(int i, int j, int value)
        {
            int index = Index(i, j);
            if (index != -1)
            {
                this.vec[index] = value;
            }
            else
            {
                throw new InvalidOperationException("This Index is already set to zero.");
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if(a.size != b.size)
            {
                throw new ArgumentException("Matrix are not of the same dimension.");
            }
            Matrix result = new Matrix(a.size);
            for(int i = 0; i<a.vec.Count; i++)
                {
                    result.vec[i] = a.vec[i] + b.vec[i];
                }
            return result;
         }

        public void Print()
        {
            for(int i = 1; i <= size; i++)
            {
                Console.Write("\t|");
                for(int j=1; j<= size; j++)
                {
                    Console.Write($" {this.getElement(i,j)}");
                }
                Console.WriteLine(" |");
            }
        }

        public static Matrix operator *(Matrix a,Matrix b)
        {
            if (a.size != b.size)
            {
                throw new ArgumentException("Matrix are not of the same dimension.");
            }
            Matrix result = new Matrix(a.size);

            for (int i = 1; i <= a.size; i++)
            {

                for (int j = 1; j <= a.size; j++)
                {
                    if (j == 1 || j == a.size || i == j)
                    {                                                                                                                                                            
                        int sum = 0;
                        for (int k = 0; k <= a.size; k++)
                        {
                            if (k == 1 || k == a.size || j == k)
                            {
                                sum += a.getElement(i, k) * b.getElement(k, j);
                            }
                        }
                        result.setElement(i, j, sum);
                    }
                }

            }
            return result;
        }

        public bool IsEqual(Matrix b)
        {
            bool equal = true;
            for(int i = 1; i <= this.size; i++)
            {
                for(int j=1;j<= this.size; j++)
                {
                    if (this.getElement(i, j) != b.getElement(i, j))
                    {

                        equal = false;
                    }
                }
            }
            return equal;
        }

        
    }
}
