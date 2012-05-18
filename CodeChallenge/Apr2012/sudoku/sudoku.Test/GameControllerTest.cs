using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace sudoku.Test
{
    /// <summary>
    ///This is a test class for GameControllerTest and is intended
    ///to contain all GameControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameControllerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for GetSudokuNumbers
        ///</summary>
        [TestMethod()]
        public void GetSudokuNumbersTest()
        {
            List<int> actual = GameController.GetSudokuProblem(36);

            Assert.AreEqual(81, actual.Count);

            /*Count the number of 0's */
            int count = 0;
            foreach(int value in actual)
            {
                if (value == 0)
                {
                    count++;
                }    
            }
            Assert.AreEqual(46, count);
        }

        /// <summary>
        ///A test for GetSudokuNumbers
        ///</summary>
        [TestMethod()]
        public void IsSudokuValidTest()
        {
            List<int> actual = GameController.GetSudokuProblem(36);

        }
    }
}
