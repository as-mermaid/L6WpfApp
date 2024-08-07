using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace L6WpfApp
{
    enum Precipitation
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    }
    internal class WeatherControl : DependencyObject
    {
        private string windDiredction;
        private double windSpeed;
        private Precipitation precipitation;
        public static readonly DependencyProperty TemperatureProperty;

        public string WindDirection { get; set; }
        public double WindSpeed { get; set; }
        Precipitation Precipitation { get; set; }

        public WeatherControl(string windDirection, double windSpeed, Precipitation precipitation)
        {
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.Precipitation = precipitation;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure|
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature)
                );
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v <= 50 && v >= -50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v > 50)
                return 50;
            else if (v <-50)
                return -50;
            else
                return v;
        }

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty,value);
        }

    }
}
