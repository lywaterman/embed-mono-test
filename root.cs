using System;
using Mono.CSharp;

class MyWorld {
	public Evaluator evaluator;

	public MyWorld (string [] args)
	{
		evaluator = new Evaluator (new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
	}

	public bool Run(string code) {
		Console.WriteLine(code);
		return evaluator.Run("var x = 1;");
	}
}

