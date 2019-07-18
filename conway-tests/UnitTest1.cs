using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cell = conway_backend.Cell;
namespace conway_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cell target = new Cell(true);
            for (int i = 0; i < 8; i++)
            {
                target.AddNeighbour(new Cell(false));
            }
            target.NextStep();
            target.Update();
            Assert.IsFalse(target.Alive);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Cell target = new Cell(false);
            for (int i = 0; i < 5; i++)
            {
                target.AddNeighbour(new Cell(false));
            }
            for (int i = 0; i < 3; i++)
            {
                target.AddNeighbour(new Cell(true));
            }
            target.NextStep();
            target.Update();
            Assert.IsTrue(target.Alive);
        }
    }
}
