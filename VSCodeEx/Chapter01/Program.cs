using System;
using System.Linq;
using System.Reflection;

// loop through the assemblies that this app references 
foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
{
    // load the assembly so we can read its details
    var a = Assembly.Load(new AssemblyName(r.FullName));
    // declare a variable to count the number of methods
    int methodCount = 0;
    // loop through all the types in the assembly
    foreach (var t in a.DefinedTypes)
    {
        // add up the counts of methods
        methodCount += t.GetMethods().Count();
    }
    // output the count of types and their methods
    Console.WriteLine(
      "{0:N0} types with {1:N0} methods in {2} assembly.",
      arg0: a.DefinedTypes.Count(),
      arg1: methodCount,
      arg2: r.Name);


}


Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");
Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");
Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");


Console.WriteLine("Using doubles:");
double a1 = 0.1;
double b = 0.2;
if (a1 + b == 0.3)
{
  Console.WriteLine($"{a1} + {b} equals 0.3");
}
else
{
  Console.WriteLine($"{a1} + {b} does NOT equal 0.3");
}

Console.WriteLine("Using decimals:");
decimal c = 0.1M; // M suffix means a decimal literal value
decimal d = 0.2M;
if (c + d == 0.3M)
{
  Console.WriteLine($"{c} + {d} equals 0.3");
}
else
{
  Console.WriteLine($"{c} + {d} does NOT equal 0.3");
}