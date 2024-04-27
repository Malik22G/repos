using System;
namespace Matrix_nps;

    public class Matrix:Exception
    {
        private int[] vec;
        private int size;

        public Matrix(int size)
        {
            this.vec = new int[3*size -2];
            this.size = size;
        }

        private int Index(int i, int j)
        {
            if (i == j)
            {
                return 2 * size +i -1;
            }
            if (j == 1)
            {
                return (i-1);
            }
            if(j==size)
            {
                return size + i - 1;
            }
            return -1;
        }
        public int getElement(int i, int j)
        {
            int index = Index(i, j);
            if (index == -1) return 0;
            return this.vec[index];
        }

        public void setElement(int i, int j,int value)
        {
            int index = Index(i, j);
            if(index!=-1)
            {
                this.vec[index] = value;
            }
            else
            {
                throw new Exception("This Index is already set to zero.");
            }
        }

        public static Matrix operator +(Matrix a,Matrix b)
        {
            if(a.size != b.size)
            { 
                throw new Exception("Matrix are not of the same dimension.");
            }
            Matrix result = new Matrix(a.size);
                for(int i = 0; i < a.vec.Length; i++)
            {
                result.vec[i] = a.vec[i] + b.vec[i];
            }
            return result;
         }


        
    }

