using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Google.Places;


namespace Customer
{
    [Activity(Label = "Activity_Map_Customer", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class Activity_Map_Customer : AppCompatActivity, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        TextView txtLocation;
        LinearLayout locationLayout;
        Button confAddr;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Map_Customer);
            // Create your application here
            FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            txtLocation = (TextView)FindViewById(Resource.Id.textViewLocation);
            locationLayout = (LinearLayout)FindViewById(Resource.Id.locationLayout);
            confAddr = (Button)FindViewById(Resource.Id.LocationOKButton);

            locationLayout.Click += LocationLayout_Click;

            confAddr.Click += ConfAddr_Click;

            InitilizePlaces();
        }

        private void ConfAddr_Click(object sender, EventArgs e)
        {
            Intent resultIntent = new Intent(this,typeof(Customer.activity_UpdateAccount_Customer));
            resultIntent.PutExtra("addrData", txtLocation.Text);
            resultIntent.PutExtra("tt", "1");
            SetResult(Android.App.Result.Ok, resultIntent);
            Finish();
            StartActivity(resultIntent);
        }

        private void LocationLayout_Click(object sender, EventArgs e)
        {
            //Intent intent = new PlaceAutocomplete.IntentBuilder(PlaceAutocomplete.ModeOverlay).Build(this);
            //StartActivityForResult(intent, 1);

            List<Place.Field> fields = new List<Place.Field>();
            fields.Add(Place.Field.Id);
            fields.Add(Place.Field.Name);
            fields.Add(Place.Field.LatLng);
            fields.Add(Place.Field.Address);
            Intent intent = new Autocomplete.IntentBuilder(AutocompleteActivityMode.Overlay, fields).SetCountry("VN").Build(this);
            StartActivityForResult(intent, 1);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1)
            {
                if (resultCode == Android.App.Result.Ok)
                {
                    var place = Autocomplete.GetPlaceFromIntent(data);
                    txtLocation.Text = place.Address.ToString();
                    mMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(place.LatLng, 15));
                }
            }
        }

        void InitilizePlaces()
        {
            string mapkey = Resources.GetString(Resource.String.map_key);
            if (!PlacesApi.IsInitialized)
            {
                PlacesApi.Initialize(this, mapkey);
            }
        }
    }
}