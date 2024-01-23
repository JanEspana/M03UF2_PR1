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
        public void NotInRangeTest()
        {
            int num = 2, max = 1, min = 0;
            bool expected = false;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.InRange(num, max, min));
        }

        [TestMethod]
        public void NameCheckTest()
        {
            string names = "Adolfo, Juan, Pedro, Luis";
            bool expected = true;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.NameCheck(names));
        }
        public void NameCheckTestFail()
        {
            string names = "Adolfo, Juan, Pedro Luis";
            bool expected = false;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.NameCheck(names));
        }
        //el método RandomStats, al igual que el método Turns, devuelven aleatorio,
        //por lo que no puedo hacer un test para comprobar si es correcto.
        [TestMethod]
        public void AttackTest()
        {
            double atk = 120, monsterHp = 3000, monsterDf = 15;
            double expected = 2898;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.Attack(atk, monsterHp, monsterDf));
        }
        public void AttackTestFail()
        {
            double atk = -100, monsterHp = -1300, monsterDf = -20;
            double expected = 0;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.Attack(atk, monsterHp, monsterDf));
        }
        [TestMethod]
        public void HealTest()
        {
            double[] hp = { 1000, 2000, 3000, 0, 5000 };
            double[] maxHp = { 2000, 2000, 3300, 4000, 5800 };
            double[] expected = { 1500, 2000, 3300, 0, 5500 };
            CollectionAssert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.Heal(hp, maxHp));
        }
        public void HealTestFail()
        {
            double[] hp = { -1000, -2000, -3000, -4000, -5000 };
            double[] maxHp = { 2000, 2000, 3300, 4000, 5800 };
            double[] expected = { 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.Heal(hp, maxHp));
        }
        [TestMethod]
        public void BubbleSortTest()
        {
            double[] hp = { 1000, 2000, 3000, 1500, 5000 };
            double[] expected = { 5000, 3000, 2000, 1500, 1000 };
            CollectionAssert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.BubbleSort(hp));
        }
        public void BubbleSortTestFail()
        {
            double[] hp = { 1000, 2000, 3000, 4000, 5000 };
            double[] expected = { 5000, 3000, 2000, 4000, 1000 };
            CollectionAssert.AreNotEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.BubbleSort(hp));
        }
        [TestMethod]
        public void NameSortTest()
        {
            double[] hp = { 1000, 2000, 3000, 1500 }, auxHp = { 3000, 2000, 1500, 1000 };
            string[] names = { "Adolfo", "Juan", "Pedro", "Luis", };
            string[] expected = { "Pedro", "Juan", "Luis", "Adolfo" };
            CollectionAssert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.NameSort(names, auxHp, hp));
        }
        public void NameSortTestFail()
        {
            double[] hp = { 1000, 2000, 3000, 1500 }, auxHp = { 3000, 2000, 1500, 1000 };
            string[] names = { "Adolfo", "Juan", "Pedro", "Luis", };
            string[] expected = { "Adolfo", "Juan", "Pedro", "Luis" };
            CollectionAssert.AreNotEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.NameSort(names, auxHp, hp));
        }
    }
}