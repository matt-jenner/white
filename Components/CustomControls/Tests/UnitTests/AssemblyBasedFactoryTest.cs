using System.Reflection;
using NUnit.Framework;
using White.CustomControls.Peers.Automation;
using White.CustomControls.UnitTests.Automation;

namespace White.CustomControls.UnitTests
{
    [TestFixture]
    public class AssemblyBasedFactoryTest
    {
        private CommandAssembly commandAssembly;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            commandAssembly = new CommandAssembly(Assembly.GetExecutingAssembly(), new KnownTypeHolderStub());
        }

        [Test]
        public void Create()
        {
            object o = commandAssembly.Create(typeof(AssemblyBasedFactoryTest).FullName);
            Assert.AreNotEqual(null, o);
        }

        [Test]
        public void CreateWithArguments()
        {
            object o = commandAssembly.Create(typeof (ForAssemblyBasedFactoryTest).FullName, "bar");
            Assert.AreNotEqual(null, o);
        }
    }

    public class ForAssemblyBasedFactoryTest
    {
        private readonly string foo;

        public ForAssemblyBasedFactoryTest(string foo)
        {
            this.foo = foo;
        }
    }
}