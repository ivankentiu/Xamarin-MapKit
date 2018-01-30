using System;
using System.Collections.Generic;
using MapKit;
using CoreLocation;
using UIKit;

namespace AR_HUNT
{
    public partial class ViewController : UIViewController
    {
        List<ARItem> targets;

        CLLocationManager locationManager;

        protected ViewController(IntPtr handle) : base(handle)
        {
            targets = new List<ARItem>();
            locationManager = new CLLocationManager();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            mapView.UserTrackingMode = MKUserTrackingMode.FollowWithHeading;
            SetupLocations();

            if (CLLocationManager.Status == CLAuthorizationStatus.NotDetermined)
            {
                locationManager.RequestWhenInUseAuthorization();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void SetupLocations()
        {
            var firstTarget = new ARItem { ItemDescription = "wolf", Location = new CLLocation(10.3349, 123.9174) };
            targets.Add(firstTarget);

            var secondTarget = new ARItem { ItemDescription = "wolf", Location = new CLLocation(10.3348, 123.9174) };
            targets.Add(secondTarget);

            var thirdTarget = new ARItem { ItemDescription = "dragon", Location = new CLLocation(10.3347, 123.9174) };
            targets.Add(thirdTarget);

            foreach (var item in targets)
            {
                var annotation = new MapAnnotation(item.Location.Coordinate, item);
                mapView.AddAnnotation(annotation);
            }

            var coordinations = new CLLocationCoordinate2D(10.3349, 123.9174);
            var span = new MKCoordinateSpan();
            mapView.Region = new MKCoordinateRegion(coordinations, span);
        }


    }
}
