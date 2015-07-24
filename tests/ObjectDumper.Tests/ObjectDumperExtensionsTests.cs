using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace ObjectDumper.Tests
{

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

        [Fact]
        public void DumpToDebug_ReturnsSameInstancePassedToIt()
        {
            var obj = new object();
            object output = obj.Dump("name");

            Assert.Equal(output, obj);
        }
		[Theory]
		[InlineData((string)null)]
		[InlineData("")]
		[InlineData(" \t\r\n ")]
        public void DumpToDebug_NullOrEmptyName_ThrowsArgumentNullException(string name)
        {
            var obj = new object();

            Assert.Throws<ArgumentNullException>(() => obj.Dump(name));
        }

        [Fact]
        public void DumpToDebug_OutputsToDebug()
        {
            var obj = new object();
            string name = Guid.NewGuid().ToString();

            var listener = new Listener();
            Debug.Listeners.Add(listener);
            obj.Dump(name);
            Debug.Listeners.Remove(listener);

            Assert.Contains(name,listener.Output.ToString() );
        }

        [Fact]
        public void PointersDoNotCauseNotCauseEndlessRecursion()
        {
            var obj = new EncoderExceptionFallbackBuffer();
            obj.Dump("buffer");
        }

        [Fact]
        public void DelegatesDoesNotCauseEndlessRecursion()
        {
            Action obj = Console.WriteLine;
            obj.Dump("action");
        }

		[Fact]
		public void DumpToString_innerException()
		{
			try
			{
				throw new ApplicationException("1");
			}
			catch (Exception e1)
			{
				try
				{
					throw new ApplicationException("2", e1);
				}
				catch (Exception e2)
				{
					try
					{
						throw new ApplicationException("3", e2);
					}
					catch (Exception e3)
					{
						var result = e1.DumpToString("test");
						Assert.Contains("1", result);
						Assert.Contains("2", result);
						Assert.Contains("3", result);
					}
				}
			}
		}

		[Fact]
		public void DumpToSting_allDepth()
		{
			var result = Node.Root.DumpToString( "root");
			Assert.Contains("left sub-tree", result);
			Assert.Contains("left-left sub-tree", result);
			var expected = readSample(MethodBase.GetCurrentMethod().Name);
			Assert.Equal(expected, result);
		}


		private string readSample(string name)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = this.GetType().Namespace + "." + name + ".txt";

			using (var stream = assembly.GetManifestResourceStream(resourceName))
			using (var reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}