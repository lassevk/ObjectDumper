using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            object output = obj.Dump("name");

            Assert.That(output, Is.SameAs(obj));
        }

        [TestCase((string)null)]
        [TestCase("")]
        [TestCase(" \t\r\n ")]
        public void DumpToDebug_NullOrEmptyName_ThrowsArgumentNullException(string name)
        {
            var obj = new object();

            Assert.Throws<ArgumentNullException>(() => obj.Dump(name));
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