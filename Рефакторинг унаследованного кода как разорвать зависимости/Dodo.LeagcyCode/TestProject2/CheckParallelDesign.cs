using NUnit.Framework;
using ParallelDesign;
using StaticClass;

namespace TestProject2
{
    public class CheckParallelDesign
    {
        [Test]
        public void ShouldBe()
        {
            Assert.AreEqual("*** gogog ***", Utils.FormatStars("gogog"));
            Assert.AreEqual("$$$ gogog $$$", Utils.FormatDollars("gogog"));
            Assert.AreEqual("    gogog    ", Utils.FormatSpaces("gogog"));
        }
    }
}