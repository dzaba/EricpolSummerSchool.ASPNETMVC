using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayoffsCreator.BL;

namespace UnitTestProject
{
    [TestClass]
    public class TreeDecoratorTest
    {
        private IGameGenerator gameGenerator;

        [TestInitialize]
        public void SetUp()
        {
           gameGenerator = new GameGenerator(); 
        }

        [TestCleanup]
        public void TearDown()
        {
            gameGenerator = null;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var tree = gameGenerator;
        }
    }
}
