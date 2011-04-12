namespace Tests
open NUnit.Framework
open FsUnit
open System.Numerics
open System.Xml
open System.Xml.Linq

[<TestFixture>]
type ``Given a list of 3 stocks`` () =
 let stockList = ["msft";"orcl";"ebay"]

 [<Test>] member x.
  ``when i ask for my stock analyzer for one day I should get a list for each stock`` () =
    Async.StockAnalyzer.GetAnalyzers(stockList, 1) |> Seq.length |> should equal stockList.Length

 [<Test>] member x.
  ``when i ask for my stock analyzer for three days`` () =
    Async.StockAnalyzer.GetAnalyzers(stockList, 3) |> Seq.length |> should equal stockList.Length


[<TestFixture>]
type ``Given a request to 7digital API artist details`` () =
 let req = new SevenDigital.Api()
 let xname sname = XName.Get sname
 let xattr (elem: XElement) sname = elem.Attribute(xname sname).Value

 [<Test>] member x.
  ``When I send the request for id 1`` () =
   req.GetArtistReleasesXml() |> should not (equal EmptyString)

 [<Test>] member x.
  ``When I send the request for id 1 as XDocument`` () =
   req.GetArtistReleases() |> should not (equal EmptyString)
