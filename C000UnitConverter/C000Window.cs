using System;
using System.Windows.Forms;

namespace C000UnitConverter
{
    /// <summary>
    /// Contains constructor and event methods for Window class
    /// </summary>
    public partial class C000Window : Form
    {
        /// <summary>
        /// Window Constructor
        /// </summary>
        public C000Window()
        {
            InitializeComponent();
            InitDefaultValues();
            InitEventHandlers();
        }

        #region Event methods

        #region Mass

        private void NumericUpDownGrams_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 0);
        }

        private void NumericUpDownLbs_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 1);
        }

        private void NumericUpDownOz_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 2);
        }

        private void ComboBoxM_Changed(object sender, EventArgs e)
        {
            NumericUpDownGrams_ValueChanged(numericUpDownGrams, e);
        }

        #endregion

        #region Length

        private void NumericUpDownM_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 0);
        }

        private void NumericUpDownIn_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 1);
        }

        private void NumericUpDownF_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 2);
        }

        private void NumericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 3);
        }

        private void NumericUpDownMi_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 4);
        }

        private void ComboBoxL_Changed(object sender, EventArgs e)
        {
            NumericUpDownM_ValueChanged(numericUpDownM, e);
        }

        #endregion

        #region Area

        private void NumericUpDownM2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 0);
        }

        private void NumericUpDownIn2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 1);
        }

        private void NumericUpDownF2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 2);
        }

        private void NumericUpDownY2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 3);
        }

        private void NumericUpDownMi2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 4);
        }

        private void ComboBoxA_Changed(object sender, EventArgs e)
        {
            NumericUpDownM_ValueChanged(numericUpDownM2, e);
        }

        #endregion

        #region Volume

        private void NumericUpDownM3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 0);
        }

        private void NumericUpDownIn3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 1);
        }

        private void NumericUpDownGal_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 2);
        }

        private void NumericUpDownF3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 3);
        }

        private void NumericUpDownL_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 4);
        }

        private void ComboBoxV_Changed(object sender, EventArgs e)
        {
            NumericUpDownM_ValueChanged(numericUpDownM3, e);
        }

        #endregion

        #region Speed

        private void NumericUpDownMs_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 0);
        }

        private void NumericUpDownKmh_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 1);
        }

        private void NumericUpDownMph_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 2);
        }

        private void NumericUpDownFps_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownUpdate(((NumericUpDown)sender).Value, 3);
        }


        private void ComboBoxS_Changed(object sender, EventArgs e)
        {
            NumericUpDownM_ValueChanged(numericUpDownMS, e);
        }

        #endregion

        #endregion

        /// <summary>
        /// Sets correct values to numericupdown boxes
        /// </summary>
        /// <param name="val">Value used for calculations</param>
        /// <param name="i">Index val's unit</param>
        /// Units
        /// Mass: Grams, Ounces, Pounds
        /// Length: Metres, Inches, Feet, Yards, Miles
        /// Area: Square Metres, Square Inches, Square Feet, Square Yards, Square Miles
        /// Volume: Cubic Meters, Cubic Inches, Gallons, Cubic Feet, Liters
        /// Speed: Meters per Second, Kilometers per Hour, Miles per Hour, Feet per Second
        private void NumericUpDownUpdate(decimal val, int i)
        {
            

            if (tabControl.SelectedIndex == 0)
            {
                decimal[] a = C000.Calc(val, i, tabControl.SelectedIndex, 9.0 - (double)comboBoxM.SelectedIndex * 3.0);

                numericUpDownGrams.ValueChanged -= gChanged;
                numericUpDownLbs.ValueChanged -= lbsChanged;
                numericUpDownOz.ValueChanged -= ozChanged;

                if (i != 0) numericUpDownGrams.Text = a[0].ToString();
                if (i != 1) numericUpDownLbs.Text = a[1].ToString();
                if (i != 2) numericUpDownOz.Text = a[2].ToString();

                numericUpDownGrams.ValueChanged += gChanged;
                numericUpDownLbs.ValueChanged += lbsChanged;
                numericUpDownOz.ValueChanged += ozChanged;
            }
            else if(tabControl.SelectedIndex == 1)
            {
                decimal[] a = C000.Calc(val, i, tabControl.SelectedIndex, 9.0 - (double)comboBoxL.SelectedIndex * 3.0);

                numericUpDownM.ValueChanged -= mChanged;
                numericUpDownIn.ValueChanged -= inChanged;
                numericUpDownF.ValueChanged -= fChanged;
                numericUpDownY.ValueChanged -= yChanged;
                numericUpDownMi.ValueChanged -= miChanged;

                if (i != 0) numericUpDownM.Text = a[0].ToString();
                if (i != 1) numericUpDownIn.Text = a[1].ToString();
                if (i != 2) numericUpDownF.Text = a[2].ToString();
                if (i != 3) numericUpDownY.Text = a[3].ToString();
                if (i != 4) numericUpDownMi.Text = a[4].ToString();

                numericUpDownM.ValueChanged += mChanged;
                numericUpDownIn.ValueChanged += inChanged;
                numericUpDownF.ValueChanged += fChanged;
                numericUpDownY.ValueChanged += yChanged;
                numericUpDownMi.ValueChanged += miChanged;

            } 
            else if (tabControl.SelectedIndex == 2)
            {
                decimal[] a = C000.Calc(val, i, tabControl.SelectedIndex, 9.0 - (double)comboBoxA.SelectedIndex * 3.0);

                numericUpDownM2.ValueChanged -= m2Changed;
                numericUpDownIn2.ValueChanged -= in2Changed;
                numericUpDownF2.ValueChanged -= f2Changed;
                numericUpDownY2.ValueChanged -= y2Changed;
                numericUpDownMi2.ValueChanged -= mi2Changed;

                if (i != 0) numericUpDownM2.Text = a[0].ToString();
                if (i != 1) numericUpDownIn2.Text = a[1].ToString();
                if (i != 2) numericUpDownF2.Text = a[2].ToString();
                if (i != 3) numericUpDownY2.Text = a[3].ToString();
                if (i != 4) numericUpDownMi2.Text = a[4].ToString();

                numericUpDownM2.ValueChanged += m2Changed;
                numericUpDownIn2.ValueChanged += in2Changed;
                numericUpDownF2.ValueChanged += f2Changed;
                numericUpDownY2.ValueChanged += y2Changed;
                numericUpDownMi2.ValueChanged += mi2Changed;
            }
            else if (tabControl.SelectedIndex == 3)
            {
                decimal[] a = C000.Calc(val, i, tabControl.SelectedIndex, 9.0 - (double)comboBoxV.SelectedIndex * 3.0);

                numericUpDownM3.ValueChanged -= m3Changed;
                numericUpDownIn3.ValueChanged -= in3Changed;
                numericUpDownGal.ValueChanged -= galChanged;
                numericUpDownF3.ValueChanged -= f3Changed;
                numericUpDownL.ValueChanged -= lChanged;

                if (i != 0) numericUpDownM3.Text = a[0].ToString();
                if (i != 1) numericUpDownIn3.Text = a[1].ToString();
                if (i != 2) numericUpDownGal.Text = a[2].ToString();
                if (i != 3) numericUpDownF3.Text = a[3].ToString();
                if (i != 4) numericUpDownL.Text = a[4].ToString();

                numericUpDownM3.ValueChanged += m3Changed;
                numericUpDownIn3.ValueChanged += in3Changed;
                numericUpDownGal.ValueChanged += galChanged;
                numericUpDownF3.ValueChanged += f3Changed;
                numericUpDownL.ValueChanged += lChanged;
            }
            else
            {
                decimal[] a = C000.Calc(val, i, tabControl.SelectedIndex, 9.0 - (double)comboBoxS.SelectedIndex * 3.0);

                numericUpDownMS.ValueChanged -= msChanged;
                numericUpDownKmh.ValueChanged -= kmhChanged;
                numericUpDownMph.ValueChanged -= mphChanged;
                numericUpDownFps.ValueChanged -= fpsChanged;

                if (i != 0) numericUpDownMS.Text = a[0].ToString();
                if (i != 1) numericUpDownKmh.Text = a[1].ToString();
                if (i != 2) numericUpDownMph.Text = a[2].ToString();
                if (i != 3) numericUpDownFps.Text = a[3].ToString();

                numericUpDownMS.ValueChanged += msChanged;
                numericUpDownKmh.ValueChanged += kmhChanged;
                numericUpDownMph.ValueChanged += mphChanged;
                numericUpDownFps.ValueChanged += fpsChanged;
            }
        }

    }
}