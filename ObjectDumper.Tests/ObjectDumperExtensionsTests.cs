using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace ObjectDumper.Tests
{
    [TestFixture]
    public class ObjectDumperExtensionsTests
    {
        public class Listener : TraceListener
        {
            public readonly StringBuilder Output = new StringBuilder();

            public override void Write(string message)
            {
                Output.Append(message);
            }

            public override void WriteLine(string message)
            {
                Output.AppendLine(message);
            }
        }

        [Test]
        public void DumpToDebug_ReturnsSameInstancePassedToIt()
        {
            var obj = new object();
            object output = obj.Dump();

            Assert.That(output, Is.SameAs(obj));
        }

        [Test]
        public void DumpToDebug_OutputsToDebug()
        {
            var obj = new object();
            string name = Guid.NewGuid().ToString();

            var listener = new Listener();
            Debug.Listeners.Add(listener);
            obj.Dump(name);
            Debug.Listeners.Remove(listener);

            Assert.That(listener.Output.ToString(), Is.StringContaining(name));
        }
    }
}