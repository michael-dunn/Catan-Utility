using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;

namespace CatanUtility.TestsOld
{
    public class GameUtilityTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void GetVerticeIndex()
        {
            Assert.AreEqual(GameUtility.GetBoardIndex(1,2), 4);

            Assert.AreEqual(GameUtility.GetBoardIndex(2,3), 9);

            Assert.AreEqual(GameUtility.GetBoardIndex(3,4), 14);

            Assert.AreEqual(GameUtility.GetBoardIndex(4,5), 16);

            Assert.AreEqual(GameUtility.GetBoardIndex(5,6), 12);

            Assert.AreEqual(GameUtility.GetBoardIndex(6,1), 9);
        }
    }
}