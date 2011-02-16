<Query Kind="Program">
  <Reference Relative="..\ObjectDumper\bin\Debug\ObjectDumper.dll">C:\Dev\VS.NET\ObjectDumper\ObjectDumper\bin\Debug\ObjectDumper.dll</Reference>
  <Namespace>ObjectDumper</Namespace>
</Query>

void Main()
{
	string s = "test string";
    ObjectDumperExtensions.Dump(s);
}

// Define other methods and classes here
