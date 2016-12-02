using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WorkSphere.Model
{
    public class Position
    {

        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude
        {
            get; private set;
        }

        public double Longitude
        {
            get; private set;
        }
    }
}
