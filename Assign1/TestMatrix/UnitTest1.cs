
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix_nps
{
    [TestClass]
    public class UnitTest1 : Exception
    {
        [TestMethod]
        public void TestNegativeSizeException()
        {
            try
            {
                Matrix M1 = new Matrix(-3);
                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]

        public void TestgetElementsOutsideRangeException()
        {
            Matrix M1 = new Matrix(3);
            try
            {
                M1.getElement(4, 5);
                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void TestgetElementInitialValues()
        {
            Matrix M1 = new Matrix(5);

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (M1.getElement(i, j) != 0)
                    {
                        Assert.IsTrue(false);
                    }
                }
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestSetElementInvalidOperationException()
        {
            Matrix M1 = new Matrix(3);

            try
            {
                M1.setElement(1, 2, 5);
                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestAdd()
        {

            Matrix M1 = new Matrix(3);
            Matrix M2 = new Matrix(3);

            for (int i = 1; i <= 3; i++)
            {

                for (int j = 1; j <= 3; j++)
                {
                    if (j == 1 || j == 3 || i == j)
                    {
                        M1.setElement(i, j, j);
                        M2.setElement(i, j, j);
                    }
                }

            }

            Matrix M3 = new Matrix(3);
            M3.setElement(1, 1, 2);
            M3.setElement(2, 2, 4);
            M3.setElement(3, 3, 6);
            M3.setElement(2, 1, 2);
            M3.setElement(2, 3, 6);
            M3.setElement(3, 1, 2);
            M3.setElement(1, 3, 6);


            Assert.IsTrue((M1+M2).IsEqual(M3));

            Assert.IsTrue((M1+M2).IsEqual(M2+M1));

            Matrix zero = new Matrix(3);
            Assert.IsTrue((M1 + zero).IsEqual(M1));

            Assert.IsTrue((M1 + M2 + M3).IsEqual((M1 + M2) + M3));


        }

        [TestMethod]
        public void TestMultiply()
        {
            Matrix M1 = new Matrix(3);
            Matrix M2 = new Matrix(3);

            for (int i = 1; i <= 3; i++)
            {

                for (int j = 1; j <= 3; j++)
                {
                    if (j == 1 || j == 3 || i == j)
                    {
                        M1.setElement(i, j, j);
                        M2.setElement(i, j, j);
                    }
                }
            }
                Matrix M3 = new Matrix(3);
                M3.setElement(1, 1, 4);
                M3.setElement(2, 2, 4);
                M3.setElement(3, 3, 12);
                M3.setElement(2, 1, 4);
                M3.setElement(2, 3, 12);
                M3.setElement(3, 1, 4);
                M3.setElement(1, 3, 12);

                Matrix result = M1 * M2;
                Assert.IsTrue(result.IsEqual(M3));
                
                Matrix M4 = new Matrix(6);

                Assert.ThrowsException<ArgumentException>(()=>M1*M4);

            Matrix zero = new Matrix(3);

            Matrix identity = new Matrix(3);

            identity.setElement(1, 1, 1);
            identity.setElement(2, 2, 1);
            identity.setElement(3, 3, 1);

            Assert.IsTrue((M1*zero).IsEqual(zero));

            Assert.IsTrue((M1 * identity).IsEqual(M1));

        }


        }


    }

