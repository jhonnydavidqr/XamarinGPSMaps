﻿using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App1GPS.Pages
{
    class GoogleMapScreen : ContentPage
    {
        public GoogleMapScreen()
        {
            GoogleMapScreenLayout();
        }

        #region initialize  
        Label lblLat = new Label();
        Label lblLong = new Label();
        Map map = new Map();
        #endregion

        public void GoogleMapScreenLayout()
        {
            #region label latitude  
            lblLat = new Label
            {
                Text = "Lat",
                FontSize = 20,
                TextColor = Color.Gray
            };
            StackLayout slLblLat = new StackLayout
            {
                Children = { lblLat },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 10, 10, 10)
            };
            #endregion

            #region label longitude  
            lblLong = new Label
            {
                Text = "Long",
                FontSize = 20,
                TextColor = Color.Gray
            };
            StackLayout slLblLong = new StackLayout
            {
                Children = { lblLong },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 10, 10, 10)
            };
            #endregion

            #region button for current location  
            Button btnLatLong = new Button
            {
                Text = "Choose location",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("4690FB"),
                TextColor = Color.White,
                BorderRadius = 10,
                WidthRequest = 100,
                HeightRequest = 50,
                FontAttributes = FontAttributes.Bold
            };
            btnLatLong.Clicked += BtnLatLong_Clicked;

            StackLayout slBtnLatLong = new StackLayout
            {
                Children = { btnLatLong },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(20, 20, 20, 20)
            };
            #endregion

            #region Map  
            map = new Map
            {
                WidthRequest = 320,
                HeightRequest = 200,
                IsShowingUser = true,
                MapType = MapType.Street
            };
            StackLayout slMap = new StackLayout
            {
                Children = { map },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 10, 10, 10)
            };
            #endregion

            #region stack layouts and contents  
            StackLayout slGoogleMapScreen = new StackLayout
            {
                Children = { slLblLat, slLblLong, slBtnLatLong, slMap },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.FromHex("DDEEFD")
            };

            ScrollView svGoogleMapScreen = new ScrollView
            {
                Content = slGoogleMapScreen
            };

            Content = svGoogleMapScreen;
            #endregion
        }

        private async void BtnLatLong_Clicked(object sender, EventArgs e)
        {
            await RetrieveLocation();
        }

        private async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            lblLat.Text = "Latitude : " + position.Latitude.ToString();
            lblLong.Text = "Longitude : " + position.Longitude.ToString();

            map.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude)
                , Distance.FromMiles(1)));

        }
    }
}
