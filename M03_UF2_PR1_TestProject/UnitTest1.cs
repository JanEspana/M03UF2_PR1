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
        //el método RandomStats, al igual que el método Turns, devuelve un número aleatorio,
        //por lo que no puedo hacer un test para comprobar si es correcto.

        [TestMethod]
        public void HeroAttackTest()
        {
            double atk = 120, monsterHp = 3000, monsterDf = 15;
            double expected = 2898;
            Assert.AreEqual(expected, M03_UF2_PR1_ClassLibrary.PR1Library.HeroAttack(atk, monsterHp, monsterDf));
        }
    }
}