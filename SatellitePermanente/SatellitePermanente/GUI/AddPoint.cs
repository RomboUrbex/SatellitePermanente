﻿using SatellitePermanente.LogicAndMath;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SatellitePermanente.GUI
{
    public partial class AddPoint : Form
    {
        public AddPoint()
        {
            InitializeComponent();
        }

        private void ButtonAddPoint_Click(object sender, EventArgs e)
        {
            LogicAndMath.Point point;
            Latitude latitude = new LatitudeImpl("N",00,00,00000);
            Longitude longitude = new LongitudeImpl("E", 00, 00, 00000);
            DateTime time;
            int angle =0;
            int altitude =0;
            bool meetingPoint = false;
            bool error = false;

            if (LatitudeSignText.Text.Length >1)
            {
                MessageBox.Show("LATITUDE IS NOT VALID!\n" + "This is the acepted format: N/S - XX - XX - XX,XXX\n");
                return;
            }

            if(LongitudeSignText.Text.Length > 1)
            {
                MessageBox.Show("LATITUDE IS NOT VALID!\n" + "This is the acepted format: N/S - XX - XX - XX,XXX\n");
                return;
            }
            
            try
            {
                latitude = new LatitudeImpl(LatitudeSignText.Text, Convert.ToInt32(this.LatitudeDegreeText.Text), Convert.ToInt32(LatitudePrimeText.Text), Convert.ToDecimal(LatitudeLatterText.Text));
            }
            catch (ArgumentException Error)
            {
                error = true;
                MessageBox.Show("LATITUDE IS NOT VALID!\n" + "This is the acepted format: N/S - XX - XX - XX,XXX\n"+"Error message:"+Error.Message);
                return;
            }

            try 
            {
                longitude = new LongitudeImpl(LongitudeSignText.Text, Convert.ToInt32(this.LongitudeDegreeText.Text), Convert.ToInt32(LongitudePrimeText.Text), Convert.ToDecimal(LongitudeLatterText.Text));
            }
            catch (ArgumentException Error)
            {
                error = true;
                MessageBox.Show("LONGITUDE IS NOT VALID!\n" + "This is the acepted format: E/W - XX - XX - XX,XXX\n" + "Error message:" + Error.Message);
                return;
            }

            time = new DateTime(Convert.ToInt32(this.DateAndTimeYearText.Text), Convert.ToInt32(this.DateAndTimeMonthText.Text), Convert.ToInt32(this.DateAndTimeDayText.Text), Convert.ToInt32(this.DateAndTimeHourText.Text), Convert.ToInt32(this.DateAndTimeMinutesText.Text), 00);

            if (this.Angle.Checked)
            {
                angle = Convert.ToInt32(this.AngleText.Text);
            }

            if (this.Altitude.Checked)
            {
                altitude = Convert.ToInt32(this.AltitudeText.Text);
            }

            if (this.MeetingPoint.Checked)
            {
                meetingPoint = true;
            }

            if (!error)
            {
                if(this.Angle.Checked|| this.Altitude.Checked)
                {
                    point = new PointImpl(latitude, longitude, time, meetingPoint, angle, altitude);
                    FormBridge.returnPoint = point;
                    MessageBox.Show("THE POINT IS VALID!\n");
                    this.Close();
                }
                else
                {
                    point = new PointImpl(latitude, longitude, time, meetingPoint);
                    FormBridge.returnPoint = point;
                    MessageBox.Show("THE POINT IS VALID!\n");
                    this.Close();
                }
            }
        }
    }
}
