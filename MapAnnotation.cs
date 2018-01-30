using System;
using MapKit;
using Foundation;
using CoreLocation;

namespace AR_HUNT
{
    public class MapAnnotation : MKAnnotation
    {
        private CLLocationCoordinate2D coordinate;
        private string title;

        public ARItem Item;

        public override CLLocationCoordinate2D Coordinate
        {
            get
            {
                return coordinate;
            }
        }

        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            coordinate = value;
        }

        public override string Title
        {
            get
            {
                return title;
            }
        }

        public MapAnnotation(CLLocationCoordinate2D location, ARItem item)
        {
           
            this.coordinate = location;
            this.title = item.ItemDescription;
            this.Item = item;

            //base.Init();
        }


    }
}
