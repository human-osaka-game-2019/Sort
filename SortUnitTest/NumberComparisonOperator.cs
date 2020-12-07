using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortUnitTest
{
    [TestClass]
    public class NumberComparisonOperator
    {

        // lhs == rhs
        [TestMethod]
        public void OrMore_1()
        {
            //Arenge
            Sort.Number number = new Sort.Number(1);

            //Act
            bool result = (number <= new Sort.Number(1));
            
            //Assert
            Assert.IsTrue(result);
        }

        //lhs <= rhs
        [TestMethod]
        public void OrMore_2()
        {
            //Arenge
            Sort.Number number = new Sort.Number(1);

            //Act
            bool result = (number <= new Sort.Number(2));

            //Assert
            Assert.IsTrue(result);
        }

        //lhs >= rhs
        [TestMethod]
        public void OrMore_3()
        {
            //Arenge
            Sort.Number number = new Sort.Number(2);

            //Act
            bool result = (number <= new Sort.Number(1));

            //Assert
            Assert.IsFalse(result);
        }

        //lhs == rhs
        [TestMethod]
        public void OrLess_1()
        {
            //Arenge
            Sort.Number number = new Sort.Number(1);

            //Act
            bool result = (number >= new Sort.Number(1));

            //Assert
            Assert.IsTrue(result);
        }

        //lhs <= rhs
        [TestMethod]
        public void OrLess_2()
        {
            //Arenge
            Sort.Number number = new Sort.Number(1);

            //Act
            bool result = (number >= new Sort.Number(2));

            //Assert
            Assert.IsFalse(result);
        }

        //lhs >= rhs
        [TestMethod]
        public void OrLess_3()
        {
            //Arenge
            Sort.Number number = new Sort.Number(2);

            //Act
            bool result = (number >= new Sort.Number(1));

            //Assert
            Assert.IsTrue(result);
        }
    }
}
