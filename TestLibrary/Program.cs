using System;

namespace TestLibrary {
	class Program {
		static void Main(string[] args) {
			var tickers = new[] {"msft", "orcl", "ebay"};
			
			var stockAnalyzers = Async.StockAnalyzer.GetAnalyzers(tickers, 365);

			foreach (var a in stockAnalyzers) {
				Console.WriteLine("Ret: {0}\tStdDev:{1}", a.Return, a.StdDev);
			}

			Console.Read();
		}
	}
}
