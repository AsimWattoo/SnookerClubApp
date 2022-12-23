using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for NumberInput.xaml
    /// </summary>
    public partial class NumberInput : UserControl
    {
        #region Private Members

        /// <summary>
        /// The preiovus text value of the text box
        /// </summary>
        private string _previousText { get; set; } = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NumberInput()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// The number property
        /// </summary>
        public double Number
        {
            get { return (double)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(double), typeof(NumberInput), new PropertyMetadata(0.0d, propertyChanged));

        /// <summary>
        /// The Suffix to show with the number
        /// </summary>
        public string Suffix
        {
            get { return (string)GetValue(SuffixProperty); }
            set { SetValue(SuffixProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Suffix.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuffixProperty =
            DependencyProperty.Register("Suffix", typeof(string), typeof(NumberInput), new PropertyMetadata("", propertyChanged));

		/// <summary>
		/// The Suffix to show with the number
		/// </summary>
		public string Prefix
		{
			get { return (string)GetValue(PrefixProperty); }
			set { SetValue(PrefixProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Suffix.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty PrefixProperty =
			DependencyProperty.Register("Prefix", typeof(string), typeof(NumberInput), new PropertyMetadata("", propertyChanged));

		/// <summary>
		/// Holds value comprising of number and Suffix
		/// </summary>
		public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string), typeof(NumberInput), new PropertyMetadata(""));

        /// <summary>
        /// The minimum value for the number
        /// </summary>
        public double? Min
        {
            get { return (double?)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(double?), typeof(NumberInput), new PropertyMetadata(null));

        /// <summary>
        /// The maximum value for the number
        /// </summary>
        public double? Max
        {
            get { return (double?)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(double?), typeof(NumberInput), new PropertyMetadata(null));

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when property value changes
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void propertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
			double number = (double)d.GetValue(NumberProperty);
            string suffix = (string)d.GetValue(SuffixProperty);
            string prefix = (string)d.GetValue(PrefixProperty);
            d.SetValue(TimeProperty, $"{prefix}{number}{suffix}");
        }


        /// <summary>
        /// Fires when the up button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Max != null)
            {
                if (Number < Max)
                    Number++;
            }
            else
            {
                Number++;
            }
        }

        /// <summary>
        /// Fires when the down button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Min != null)
            {
                if (Number > Min)
                    Number--;
            }
            else
            {
                Number--;
            }
        }

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && e.Key != Key.Decimal && e.Key != Key.OemPeriod)
                e.Handled = true;

        }

        /// <summary>
        /// Fires when the text input is given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox? textbox = sender as TextBox;

            if (textbox == null)
                return;

            _previousText = textbox.Text;
        }

        /// <summary>
        /// Fires when the text of the text box changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox == null)
            {
                return;
            }
            string text = textBox.Text;
            string number = text;
            //parsing text
            if (!string.IsNullOrEmpty(Suffix))
				number = text.Replace(Suffix, "");
            if(!string.IsNullOrEmpty(Prefix))
				number = number.Replace(Prefix, "");

            double time;

            if (!double.TryParse(number, out time))
                time = 0;

            if ((Min != null && time < Min) || (Max != null && time > Max))
                textBox.Text = _previousText;
            else
                Number = time;

            if (!text.EndsWith(Suffix))
            {
                textBox.Text += Suffix;
            }
            if (!text.StartsWith(Prefix))
                textBox.Text = $"{Prefix}{textBox.Text}";
        }

        #endregion
    }
}
