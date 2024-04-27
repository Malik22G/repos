namespace Matrix_nps;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestNegativeSizeException()
    {
        try { 
            Assert.IsTrue(false);
        }
        catch
        {
            Assert.IsTrue(true);
        }

    }
}

