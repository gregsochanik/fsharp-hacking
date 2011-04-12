using System;
using System.Diagnostics;

namespace TestLibrary {
	class Program {
		static void Main(string[] args) {
			var tickers = new[] {"msft", "orcl", "ebay"};

			var stockAnalyzers = Async.StockAnalyzer.GetAnalyzers(tickers, 365);

			foreach (var stockAnalyzer in stockAnalyzers) {
				Console.WriteLine("Ret: {0}\tStdDev:{1}", stockAnalyzer.Return, stockAnalyzer.StdDev);
			}

			var api = new SevenDigital.Api();

			var artistReleases = api.GetArtistReleases();
			foreach (var artistRelease in artistReleases) {
				Console.WriteLine("ID={0}, Title={1}", artistRelease.Item1, artistRelease.Item2.Value);
			}

			Console.Read();
		}


	}
}
