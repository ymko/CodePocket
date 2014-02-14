/*
 *	how to execute
 *	C:\tmp>path=%path%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319
 *	C:\tmp>csc resource_test.cs /resource:resource_test.cs /resource:README
 *	C:\tmp>resource_test.exe
 */
namespace Main
{
	using System;
	using System.IO;
	using System.Reflection;

	class MainClass
	{
		static void Main()
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			foreach(string fname in asm.GetManifestResourceNames()) {
				Console.WriteLine("file=" + fname);
				StreamReader sr = new StreamReader(asm.GetManifestResourceStream(fname));
				
				string line;
				while ((line = sr.ReadLine()) != null) {
					Console.WriteLine(line);
				}
			}
		}
	}
}
