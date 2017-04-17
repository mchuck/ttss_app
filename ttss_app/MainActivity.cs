using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ttss_app
{
    [Activity(Label = "ttss_app", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            var data = TtssApi.get_query("50");

            var routes = new List<TtssApiTypes.Route>(data.Item1);
            var stops = new List<TtssApiTypes.Stop>(data.Item2);

            if(routes.Count > 0)
            {
                var route_stops = new List<TtssApiTypes.Stop>(TtssApi.get_route_stops(routes[0].Id));

                if(route_stops.Count > 0)
                {
                    var departures = new List<TtssApiTypes.Departure>(TtssApi.get_stop_departures(route_stops[0].Number));
                }
            }
        }
    }
}

