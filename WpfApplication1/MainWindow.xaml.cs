using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wetness_Indicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double equation_1_answer = 0;
        private double equation_2_answer = 0;


        public MainWindow()
        {
            InitializeComponent();
        } // end method

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Calculate(object sender, RoutedEventArgs e)
        {
            ClearErrorMaterials();
            labelstericwarning.Content = "";
            if (radioButton_eqn_2.IsChecked == true)
            {
                double zeta_value = 0;

                try
                {

                    label3.Background = new SolidColorBrush(Colors.LightCyan);
                    labelstericwarning.Content = "";
                    zeta_value = Convert.ToDouble(textBox_zeta.Text);
                    WaterStatusCalculation a_Calculation = new WaterStatusCalculation();
                    double res = a_Calculation.CalculateWetType(zeta_value);

                    equation_2_answer = (int)res;
                    ActivateErrorButtons(equation_2_answer);

                    textBoxres.Background = new SolidColorBrush(Colors.Red);
                    textBoxres.FontSize = 20;
                    if (equation_2_answer < 0)
                    { textBoxres.Text = " < 0"; }
                    else if (equation_2_answer > 180)
                    { textBoxres.Text = " > 180"; }
                    else
                    { textBoxres.Text = equation_2_answer.ToString(""); }

                    label3.FontSize = 20;
                    button_calculate.IsEnabled = true;

                    string message = String.Format("{0}", a_Calculation.ShowMessage(res));
                    if (message.Equals("Unidentified"))
                    {
                        label3.Background = new SolidColorBrush(Colors.Red);
                        label3.Content = string.Format("{0,28}", message);
                    }
                    else
                    {
                        label3.Background = new SolidColorBrush(Colors.CornflowerBlue);
                        label3.Content = string.Format("{0,28}", message);
                    }

                }
                catch
                {
                    label_warning_general.Foreground = new SolidColorBrush(Colors.Red);
                    label3.Content = "";
                    labelstericwarning.Foreground = new SolidColorBrush(Colors.Red);
                    labelstericwarning.Content = "Make sure input value is valid !";
                }

            } // end if

            else
            {
                string combo_res = comboBox_zeta_type.Text;
                if (combo_res == "positive potential")
                {
                    WaterStatusCalculation equation_1 = new WaterStatusCalculation();
                    double zeta_value = 0;
                    try
                    {

                        labelstericwarning.Content = "";
                        label_warning_general.Content = "";
                        label3.Background = new SolidColorBrush(Colors.LightCyan);
                        zeta_value = Convert.ToDouble(textBox_zeta.Text);
                        double steric_acid = Convert.ToDouble(textBox_steric.Text);
                        equation_1_answer = equation_1.CalculateWetType(zeta_value, steric_acid, "positive");
                        ActivateErrorButtons(equation_1_answer);
                        textBoxres.Background = new SolidColorBrush(Colors.Red);
                        textBoxres.FontSize = 20;

                        if (equation_1_answer < 0)
                        { textBoxres.Text = " < 0"; }
                        else if (equation_1_answer > 180)
                        { textBoxres.Text = " > 180"; }
                        else { textBoxres.Text = equation_1_answer.ToString(""); }

                        label3.FontSize = 20;
                        label3.Background = new SolidColorBrush(Colors.CornflowerBlue);
                        string message = String.Format("{0}", equation_1.ShowMessage(equation_1_answer));
                        if (message.Equals("Unidentified"))
                        {
                            label3.Background = new SolidColorBrush(Colors.Red);
                            label3.Content = string.Format("{0,28}", message);
                        }
                        else
                        {
                            label3.Background = new SolidColorBrush(Colors.CornflowerBlue);
                            label3.Content = string.Format("{0,28}", message);

                        } // end else

                    }
                    catch
                    {
                        label_warning_general.Foreground = new SolidColorBrush(Colors.Red);
                        label3.Content = "";
                        labelstericwarning.Foreground = new SolidColorBrush(Colors.Red);
                        labelstericwarning.Content = "Make sure all input values are valid !";
                    }

                } // end if

                else if (combo_res == "negative potential")
                {
                    WaterStatusCalculation equation_1 = new WaterStatusCalculation();
                    double zeta_value = 0;
                    try
                    {
                        labelstericwarning.Content = "";
                        label_warning_general.Content = "";
                        label3.Background = new SolidColorBrush(Colors.LightCyan);
                        zeta_value = Convert.ToDouble(textBox_zeta.Text);
                        double steric_acid = Convert.ToDouble(textBox_steric.Text);
                        equation_1_answer = equation_1.CalculateWetType(zeta_value, steric_acid, "negative");
                        ActivateErrorButtons(equation_1_answer);
                        textBoxres.Background = new SolidColorBrush(Colors.Red);
                        textBoxres.FontSize = 20;

                        if (equation_1_answer < 0)
                        { textBoxres.Text = " < 0 "; }
                        else if (equation_1_answer > 180)
                        { textBoxres.Text = " > 180"; }
                        else { textBoxres.Text = equation_1_answer.ToString(""); }


                        label3.FontSize = 20;
                        label3.Background = new SolidColorBrush(Colors.CornflowerBlue);
                        string message = String.Format("{0}", equation_1.ShowMessage(equation_1_answer));
                        if (message.Equals("Unidentified"))
                        {
                            label3.Background = new SolidColorBrush(Colors.Red);
                            label3.Content = string.Format("{0,28}", message);
                        }
                        else
                        {
                            label3.Background = new SolidColorBrush(Colors.CornflowerBlue);
                            label3.Content = string.Format("{0,28}", message);

                        } // end else

                    }
                    catch
                    {
                        // label_warning_general.Foreground = new SolidColorBrush(Colors.Red);
                        label3.Content = "";
                        labelstericwarning.Foreground = new SolidColorBrush(Colors.Red);
                        labelstericwarning.Content = "Make sure all input values are valid !";
                        // label_warning_general.Content = "Incorrect input values!";

                    }

                } // end else if
                else
                {

                    labelstericwarning.Content = "";
                    double number = 0;
                    bool value = double.TryParse(textBox_zeta.Text, out number);
                    value = double.TryParse(textBox_steric.Text, out number);
                    if (textBox_steric.Text == "" || !value)
                    {
                        labelstericwarning.Foreground = new SolidColorBrush(Colors.Red);
                        labelstericwarning.Content = "Make sure all input values are valid !";
                    }
                    value = double.TryParse(textBox_steric.Text, out number);
                    if (textBox_zeta.Text == "" || value == false)
                    {
                        labelstericwarning.Foreground = new SolidColorBrush(Colors.Red);
                        labelstericwarning.Content = "Make sure all input values are valid !";
                    } // end if

                    label_warning_general.Content = "";
                    string selected_combo = comboBox_zeta_type.Text;
                    if (selected_combo == "Select zeta potential..")
                    {
                        label_warning_general.Foreground = new SolidColorBrush(Colors.Red);
                        label_warning_general.Content = "Must select a zeta type !";
                        label3.Background = new SolidColorBrush(Colors.LightCyan);
                        label3.Content = "";
                        if (value == false)
                        {
                            labelstericwarning.Foreground = new SolidColorBrush(Colors.Red);
                            labelstericwarning.Content = "Make sure all input values are valid !";
                        } // end if
                    }

                } // end else

            } // end else

        } // end method



        private void radioButton_eqn_01_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton_eqn_01.IsChecked == true)
            {
                textBoxres.Text = "";
                textBox_steric.Text = "";
                textBox_zeta.Text = "";
                label3.Background = new SolidColorBrush(Colors.LightCyan);
                label3.Content = "";
                comboBox_zeta_type.SelectedIndex = 0;
                labelstericwarning.Content = "";
                label_warning_general.Content = "";
                comboBox_zeta_type.IsEnabled = true;
                button_calculate.IsEnabled = true;
                button_clear.IsEnabled = true;
                textBox_steric.IsEnabled = true;
                textBox_zeta.IsEnabled = true;
                groupBox_eqn_selected.Header = "Equation 1 Selected";
                textBox_steric.IsEnabled = true;

            } // end if

            ActivateErrorButtons(equation_1_answer);
            equation_2_answer = 0;
            textBoxres_Copy.Text = "";
            textBox_lab_value.Text = "";
            frame_01.Background = new SolidColorBrush(Colors.LightGray);
            label_error.Content = "";

        } // end method

        public void ClearErrorMaterials()
        {
            textBox_lab_value.Text = "";
            textBox_lab_value.IsEnabled = false;
            textBoxres_Copy.Text = "";
            button_calculate_error.IsEnabled = false;
            frame_01.Background = new SolidColorBrush(Colors.LightGray);

        } // end method ClearErrorMaterials

        private void radioButton_eqn_2_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton_eqn_2.IsChecked == true)
            {
                //comboBox_zeta_type.SelectedValue = "";
                textBoxres.Text = "";
                comboBox_zeta_type.SelectedIndex = 0;
                label3.Background = new SolidColorBrush(Colors.LightCyan);
                textBox_steric.Text = "";
                textBox_zeta.Text = "";
                label3.Content = "";
                label_warning_general.Content = "";
                labelstericwarning.Content = "";
                button_clear.IsEnabled = true;
                button_calculate.IsEnabled = true;
                groupBox_eqn_selected.Header = "Equation 2 Selected";
                textBox_steric.IsEnabled = false;
                textBox_zeta.IsEnabled = true;
                comboBox_zeta_type.IsEnabled = false;



            } // end if

            ActivateErrorButtons(equation_2_answer);
            equation_1_answer = 0;
            textBoxres_Copy.Text = "";
            textBox_lab_value.Text = "";
            frame_01.Background = new SolidColorBrush(Colors.LightGray);
            label_error.Content = "";

        } // end method



        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox_steric.Text = "";
            textBox_zeta.Text = "";
            textBoxres.Text = "";
            label3.Content = "";
            label3.Background = new SolidColorBrush(Colors.LightCyan);
            ClearErrorMaterials();
            label_error.Content = "";

            textBoxres_Copy.Background = new SolidColorBrush(Colors.Red);

            textBoxres_Copy1.Text = "";


        } // end method 

        // method GetZetaValue to get the calculated zeta value
        public double GetCalculatedZetaValue()
        {
            double zeta_value = 0;
            if (radioButton_eqn_2.IsChecked == true)
            {
                zeta_value = equation_2_answer;

            } // end if
            else
            {
                zeta_value = equation_1_answer;
            } // end else

            return zeta_value;

        } // end method GetCalculatedZetaValue


        // method CalculateErrorPercentage to calculate error percentage
        public double CalculateErrorPercentage(double zeta_value, double lab_value)
        {
            double final_answer = 0;

            final_answer = Math.Abs(((zeta_value - lab_value) / lab_value));

            return final_answer;

        } // end method CalculateErrorPercentage

        private void button_calculate_error_Click(object sender, RoutedEventArgs e)
        {

            label_error.Content = "";
            // get calculated zeta value
            double zeta_calculated = GetCalculatedZetaValue();

            // get the lab value from the text_box
            string lab_value_string = textBox_lab_value.Text;
            double lab_value = 0;
            bool lab_value_parse = double.TryParse(lab_value_string, out lab_value);
            if (!lab_value_parse)
            {

                label_error.Foreground = new SolidColorBrush(Colors.Red);
                label_error.Content = "Invalid lab value ! ";
                textBoxres_Copy1.Text = "";
                textBoxres_Copy.Text = "";
            } // end if
            else
            {
                bool infinity = false;
                if (lab_value == 0)
                {
                    label_error.Foreground = new SolidColorBrush(Colors.Red);
                    label_error.Content = "Invalid lab value ! ";
                    infinity = true;

                }
                double error_percentage = CalculateErrorPercentage(zeta_calculated, lab_value);
                double yield_percentage = CalculateYieldPercentage(zeta_calculated, lab_value);


                textBoxres_Copy.FontSize = 20;

                if (!infinity)
                {
                    if (error_percentage * 100 <= 5)
                    {
                        textBoxres_Copy.Background = new SolidColorBrush(Colors.Green);
                        textBoxres_Copy.Text = error_percentage.ToString("0.00%");

                    } // end if

                    else
                    {
                        textBoxres_Copy.Background = new SolidColorBrush(Colors.Red);
                        textBoxres_Copy.Text = error_percentage.ToString("0.00%");

                    } // end else
                } // end if
                else
                {
                    textBoxres_Copy.Text = "Invalid !";
                } // end else

                textBoxres_Copy1.FontSize = 20;
                if (yield_percentage * 100 > 100)
                    textBoxres_Copy1.Text = "> 100";
                else if (yield_percentage * 100 < 0)
                    textBoxres_Copy1.Text = "< 0";
                else
                    textBoxres_Copy1.Text = yield_percentage.ToString("0.00%");

            } // end else


        } // end method 

        // method Activate Buttons
        public void ActivateErrorButtons(double _result)
        {
            if (_result > 0 && _result <= 180)
            {
                frame_01.Background = new SolidColorBrush(Colors.Beige);
                textBox_lab_value.IsEnabled = true;

                button_calculate_error.IsEnabled = true;


                // also activate the yield box


            } // end if
            else
            {
                textBox_lab_value.IsEnabled = false;

                button_calculate_error.IsEnabled = false;

            } // end else

        } // end method ActivateErrorButtons


        // method CalculateYield to calculate the yield %
        public double CalculateYieldPercentage(double _equation_value, double _lab_value)
        {
            double divide_result = _lab_value / _equation_value;

            double final_answer = divide_result;

            return final_answer;

        } // end method CalculateYieldPercentage



    } // end Class

} // end namespace
