
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace sudoku.Test
{
    
    
    /// <summary>
    ///This is a test class for GridHelperTest and is intended
    ///to contain all GridHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridHelperTest
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
        ///A test for GetBox
        ///</summary>
        [TestMethod()]
        public void GetFirstBoxTest()
        {
            List<int> expected = new List<int>(9);
            expected.Add(0); expected.Add(1); expected.Add(2);
            expected.Add(9); expected.Add(10); expected.Add(11);
            expected.Add(18); expected.Add(19); expected.Add(20);
            
            int boxNumber = 0;
            List<int> actual = GridHelper.GetBox(boxNumber);

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            Assert.AreEqual(9, actual.Count);
        }

        /// <summary>
        ///A test for GetBox
        ///</summary>
        [TestMethod()]
        public void GetLastBoxTest()
        {
            List<int> expected = new List<int>(9);
            expected.Add(60); expected.Add(61); expected.Add(62);
            expected.Add(69); expected.Add(70); expected.Add(71);
            expected.Add(78); expected.Add(79); expected.Add(80);

            int boxNumber = 8;
            List<int> actual = GridHelper.GetBox(boxNumber);

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            Assert.AreEqual(9, actual.Count);
        }

        /// <summary>
        ///A test for GetAllSquares
        ///</summary>
        [TestMethod()]
        public void GetAllSquaresTest()
        {
            List<int> actual = GridHelper.GetAllSquares();
            Assert.AreEqual(81, actual.Count);
            Assert.AreEqual(0, actual[0]);
            Assert.AreEqual(80, actual[80]);   
        }

        /// <summary>
        ///A test for GetColumn
        ///</summary>
        [TestMethod()]
        public void GetFirstColumnTest()
        {
            List<int> expected = new List<int>(9);
            expected.Add(0);
            expected.Add(9);
            expected.Add(18);
            expected.Add(27);
            expected.Add(36);
            expected.Add(45);
            expected.Add(54);
            expected.Add(63);
            expected.Add(72);

            int columnNumber = 0;
            List<int> actual = GridHelper.GetColumn(columnNumber);
            
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            Assert.AreEqual(9, actual.Count);
        }

        /// <summary>
        ///A test for GetColumn
        ///</summary>
        [TestMethod()]
        public void GetLastColumnTest()
        {   
            List<int> expected = new List<int>(9);
            expected.Add(8);
            expected.Add(17);
            expected.Add(26);
            expected.Add(35);
            expected.Add(44);
            expected.Add(53);
            expected.Add(62);
            expected.Add(71);
            expected.Add(80);

            int columnNumber = 8;
            List<int> actual = GridHelper.GetColumn(columnNumber);

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            Assert.AreEqual(9, actual.Count);
        }

        /// <summary>
        ///A test for GetRow
        ///</summary>
        [TestMethod()]
        public void GetFirstRowTest()
        {
            int rowNumber = 0;
            List<int> expected = new List<int>(9);
            expected.Add(0); expected.Add(1); expected.Add(2); expected.Add(3); expected.Add(4); expected.Add(5); expected.Add(6); expected.Add(7); expected.Add(8); 
            List<int> actual = GridHelper.GetRow(rowNumber);
            
            Assert.AreEqual(9, actual.Count);
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        ///A test for GetRow
        ///</summary>
        [TestMethod()]
        public void GetLastRowTest()
        {
            int rowNumber = 8;
            List<int> expected = new List<int>(9);
            expected.Add(72); expected.Add(73); expected.Add(74); expected.Add(75); expected.Add(76); expected.Add(77); expected.Add(78); expected.Add(79); expected.Add(80);
            List<int> actual = GridHelper.GetRow(rowNumber);

            Assert.AreEqual(9, actual.Count);
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }   
        }
    }
}
