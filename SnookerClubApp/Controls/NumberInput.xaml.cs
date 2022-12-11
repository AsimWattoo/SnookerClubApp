using System;
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
        private string _previousText { get; set; }

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
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(NumberInput), new PropertyMetadata(0, propertyChanged));

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
        public int? Min
        {
            get { return (int?)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int?), typeof(NumberInput), new PropertyMetadata(null));

        /// <summary>
        /// The maximum value for the number
        /// </summary>
        public int? Max
        {
            get { return (int?)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int?), typeof(NumberInput), new PropertyMetadata(null));

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
            int number = (int)d.GetValue(NumberProperty);
            string suffix = (string)d.GetValue(SuffixProperty);
            d.SetValue(TimeProperty, $"{number}{suffix}");
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
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
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
            //parsing text
            string number = text.Replace(Suffix, "");
            int time = string.IsNullOrEmpty(number) ? 0 : int.Parse(number);
            if ((Min != null && time < Min) || (Max != null && time > Max))
                textBox.Text = _previousText;
            else
                Number = time;
        }

        #endregion
    }
}
