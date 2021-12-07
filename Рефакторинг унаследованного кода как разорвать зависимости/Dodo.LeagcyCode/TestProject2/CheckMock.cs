using MockProject;
using NUnit.Framework;
using Moq;

namespace TestProject2
{
    public class CheckMock
    {
        [Test]
        public void ShouldBe()
        {
            string action="test";
            Mock<SomeClass> mockSomeClass = new Mock<SomeClass>();
            
            mockSomeClass.Setup(mock => mock.DoSomething());
            
            MyClass myClass = new MyClass(mockSomeClass.Object);
            myClass.MyMethod(action);
            
            // Explicitly verify each expectation...
            mockSomeClass.Verify(mock => mock.DoSomething(), Times.Once());
            
            // ...or verify everything.
            // mockSomeClass.VerifyAll();
        }
    }
}