module TtssApi

open System
open FSharp.Data
open TtssApiTypes

let private api_base = "http://www.ttss.krakow.pl/internetservice/services/"
let private lookup_method = "lookup/autocomplete/json"
let private route_method = "routeInfo/routeStops"
let private stop_method = "passageInfo/stopPassages/stop"

let private get_data (method: string) (args: (string * string) list) = 
    Http.RequestString(api_base + method, args, httpMethod="GET")

let private get_query_data (query: string) = 
    get_data lookup_method ["query", query] |> QueryResult.Parse

let private  get_route_data (route_id: int64) = 
    get_data route_method ["routeId", route_id.ToString()] |> RouteResult.Parse

let private get_stop_data (stop_number: int) = 
    get_data stop_method [ "stop", stop_number.ToString(); "mode", "departure" ] |> StopResult.Parse

let private filter_data pred (data: QueryResult.Root[])  = 
    data |> Seq.where(fun item -> item.Type = pred)

let private get_query_routes (data: QueryResult.Root[]) =
    data 
        |> filter_data "route" 
        |> Seq.map(fun item -> new Route(item.Id, item.Name))

let private get_query_stops (data: QueryResult.Root[]) = 
    data 
        |> filter_data "stop"
        |> Seq.map(fun item -> new Stop(int64 -1, int item.Id, item.Name))

let get_query (query: String) = 
    let data = get_query_data query
    (data |> get_query_routes, data |> get_query_stops)

let get_route_stops (route_id: int64) =
    let data = get_route_data route_id
    data.Stops 
        |> Seq.map(fun item -> new Stop(item.Id, item.Number, item.Name))

let get_stop_departures (stop_number: int) = 
    let data = get_stop_data(stop_number)
    data.Actual
        |> Seq.map(fun item -> new Departure(item.ActualTime, item.MixedTime, item.Direction))
       