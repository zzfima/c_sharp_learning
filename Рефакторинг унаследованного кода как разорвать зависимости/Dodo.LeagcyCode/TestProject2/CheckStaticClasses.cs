using NUnit.Framework;
using ParallelDesign;

namespace TestProject2
{
    public class CheckStaticClasses
    {
        [Test]
        public void ShouldBe()
        {
            ContractorNew contractorNew = new ContractorNew();
            Assert.AreEqual("", "");
        }
    }
}