module TtssApiTypes

open FSharp.Data
open System

type Route(id: Int64, name: string) =
    member this.Id = id
    member this.Name = name

type Stop(id: Int64, number: int, name: string) =
    member this.Id = id
    member this.Number = number
    member this.Name = name   
    
type Departure(time: DateTime, relativeTime: string, direction: string) =
    member this.Time = time
    member this.RelativeTime = relativeTime
    member this.Direction = direction

type QueryResult = JsonProvider<""" [{"id":"6350571212602605631","name":"MPK 50","type":"route"}] """>
type RouteResult = JsonProvider<"""
{
  "route": {
    "alerts": [],
    "authority": "MPK",
    "directions": [
      "Kurdwanów",
      "Krowodrza Górka"
    ],
    "id": "6350571212602605631",
    "name": "50",
    "shortName": "50"
  },
  "stops": [
    {
      "id": "6350927454370005192",
      "name": "AWF",
      "number": "113"
    }
  ]
}
""">

type StopResult = JsonProvider<"""
{
  "actual": [
    {
      "actualRelativeTime": -4,
      "actualTime": "22:35",
      "direction": "Os.Piastów",
      "mixedTime": "0 Min",
      "passageid": "-9223372036357806828",
      "patternText": "52",
      "plannedTime": "22:35",
      "routeId": "6350571212602605638",
      "status": "STOPPING",
      "tripId": "6351558574045416209",
      "vehicleId": "6352185295672181653"
    }
  ],
  "directions": [],
  "firstPassageTime": 1492459504000,
  "generalAlerts": [],
  "lastPassageTime": 1492465380000,
  "old": [],
  "routes": [
    {
      "alerts": [],
      "authority": "MPK",
      "directions": [
        "Krowodrza Górka",
        "Czerwone Maki P+R"
      ],
      "id": "6350571212602605637",
      "name": "18",
      "routeType": "tram",
      "shortName": "18"
    }
  ],
  "stopName": "Kapelanka",
  "stopShortName": "576"
}
""">