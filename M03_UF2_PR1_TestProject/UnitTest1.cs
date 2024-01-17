namespace M03_UF2_PR1_TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InRangeTest()
        {
            int num = 1, max = 1, min = 0;
            bool expected = true;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.InRange(num, max, min));
        }
        [TestMethod]
        public void NameCheckTest()
        {
            string names = "Adolfo, Juan, Pedro, Luis";
            bool expected = true;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.NameCheck(names));
        }
    }
}