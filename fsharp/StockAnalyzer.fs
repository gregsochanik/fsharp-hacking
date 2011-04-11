module NonAsync

open System.Net
open System.IO
open System

let internal loadPrices(ticker) = 
 let url = "http://ichart.finance.yahoo.com/table.csv?s="+ticker+"&d=3&e=11&f=2011&g=d&a=6&b=19&c=2000&ignore=.csv"

 // NOTE: almost identical to c#
 let client = new WebClient()
 let csv = client.DownloadString(new Uri(url)) 

 // NOTE: fun = function
 let prices = 
  csv.Split([|'\n'|])
  |> Seq.skip 1
  |> Seq.map (fun line -> line.Split([|','|]))
  |> Seq.filter (fun values -> values |> Seq.length = 7)
  |> Seq.map(fun values -> System.DateTime.Parse(values.[0]), float values.[6])
 prices

// NOTE: an example of a class
type StockAnalyzer(lprices, days) = 
 let prices = 
  lprices 
  |> Seq.map snd
  |> Seq.take days

 static member GetAnalyzers(tickers, days) =
  tickers
  |> Seq.map loadPrices
  |> Seq.map (fun prices -> new StockAnalyzer(prices, days))

 member s.Return =
  let lastPrice = prices |> Seq.nth 0
  let startPrice = prices |> Seq.nth(days-1)
  lastPrice / startPrice - 1.

 member s.StdDev = 
  let logRets = 
   prices
   |> Seq.pairwise
   |> Seq.map(fun (x, y) -> log(x/y))
  let mean = logRets |> Seq.average
  let sqr x = x * x
  let var = logRets |> Seq.averageBy (fun r->sqr (r-mean))
  sqrt var