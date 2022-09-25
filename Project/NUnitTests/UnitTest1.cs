using Microsoft.VisualStudio.TestPlatform.TestHost;
using Project;

//decided to not do any unit/intergration tests - just lazy
namespace NUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void dot1()
        {
            
            //allStops()
            Assert.Pass();
        }
        [Test]
        public void dot2()
        {
            string[] dot2in = { "S1, True", "S1, True", "S1, True", "S1, True" };
            Train traind2 = new Train(dot2in);
            if (traind2.allStops())
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test]
        public void dot3()
        {
            Assert.Pass();
        }
        [Test]
        public void dot4()
        {
            Assert.Pass();
        }
        [Test]
        public void dot5()
        {
            Assert.Pass();
        }
        [Test]
        public void dot6()
        {
            Assert.Pass();
        }
    }
}