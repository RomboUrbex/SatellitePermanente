﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SatellitePermanente
{

    /*This Class in usefull to shape a short of standar Point of detecion in DMS format.
     This Class will be extended to Latitude Class and Longitude Class in way to specialize the coordinates*/

    public class OriginImpl: Origin
    {
        /*Fields*/
        public char sign { get; } /*Sign = 'N' 'E' 'S' 'O'*/

        public int degrees { get; }

        public int prime { get; }

        public decimal latter { get; }

        /*Builder*/
        public OriginImpl(char sign, int degrees, int prime, decimal latter)
        {
            this.sign = sign;
            this.degrees = degrees;
            this.prime = prime;
            this.latter = latter;
        }

        
        /*This method serves to print the coordinates salved*/
        public String GetString()
        {
            return Convert.ToString(this.sign) + " " + Convert.ToString(this.degrees) + "° " + Convert.ToString(this.prime) + "' " + Convert.ToString(this.latter) + "''";
        }
    }
}
