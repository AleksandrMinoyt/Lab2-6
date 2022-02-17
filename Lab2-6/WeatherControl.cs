using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2_6
{

    // (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег. 
    enum Precipitation : int
    {
        sunny = 0,
        cloudy = 1,
        rain = 2,
        snow = 3
    }

    class WeatherControl : DependencyObject
    {
        //private int _temp;
        public static readonly DependencyProperty TempProperty;
        private string _directWind;
        private int _speedWind;
        private Precipitation _precipitation;

        public WeatherControl(int Temp, string DirectWind, int SpeedWind, Precipitation Precipitation)
        {
            /* if (Temp >= -50 && Temp <= 50)
             {
                 _temp = Temp;
             }
             else
             {
                 throw new Exception("Неверное значение температуры (-50   +50 °С)");
             }
             */

            if (SpeedWind >= 0 && SpeedWind <= 100)
            {
                _speedWind = SpeedWind;
            }
            else
            {
                throw new Exception("Неверное значение скорости ветра (0  100 м/с)");
            }
            _directWind = DirectWind;
            _precipitation = Precipitation;
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp))
                    );
        }


        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int temp = (int)baseValue;
            if (temp >= -50 && temp <= 50)
            {
                return temp;
            }
            else
            {
                return 0;
            }
        }

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);

        }


        /*
            public int Temp
            {
                get { return _temp; }
                set
                {
                    if (value >= -50 && value <= 50)
                    {
                        _temp = value;
                    }
                    else
                    {
                        throw new Exception("Неверное значение температуры (-50   +50 °С)");
                    }
                }
            }
         */

        public int SpeedWind
        {
            get { return _speedWind; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _speedWind = value;
                }
                else
                {
                    throw new Exception("Неверное значение скорости ветра (0  100 м/с)");
                }
            }
        }

        public string DirectWind
        {
            get { return _directWind; }
            set
            {
                _directWind = value;
            }
        }

        public Precipitation Precipitation
        {
            get { return _precipitation; }
            set
            {
                _precipitation = value;
            }
        }



    }
}
