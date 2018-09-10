using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class WaterStatusCalculation
{
    enum WetStatus
    {
        Strongly_Wet,
        Water_Wet,
        Neutral_Wet,
        Preferentially_Oil_Wet,
        Strongly_Oil_Wet,
        None

    } // end enum

    // equation 1 constants
    private const double CONST_01_EQN_01 = 0.1482;
    private const double CONST_02_EQN_01 = -0.1782;
    private const double CONST_03_EQN_01 = 1.0026;
    private const double CONST_04_EQN_01 = 3.0166;
    private const double CONST_05_EQN_01 = 0.8796;
    private const double CONST_06_EQN_01 = 3.2078;

    // equation 2 constants
    private const double CONST_01_EQN_02 = 0.0092;
    private const double CONST_02_EQN_02 = 1.3531;
    private const double CONST_03_EQN_02 = 12.599;
    

    // equation 1 result variables

    private const int STRONGLY_WET_LOWER = 0;
    private const int STRONGLY_WET_UPPER = 29;
    private const int WATER_WET_LOWER = 30;
    private const int WATER_WET_UPPER = 89;
    private const int NEUTRAL_WET = 90;
    private const int PREFERENTIALLY_OIL_WET_LOWER = 91;
    private const int PREFERENTIALLY_OIL_WET_UPPER = 149;
    private const int STRONGLY_OIL_WET_LOWER = 150;
    private const int STRONGLY_OIL_WET_UPPER = 180;


    // method CalculateWetType to calculate wet type
    public int CalculateWetType(double zeta_potential, double stearic_acid_concentration, string zeta_type)
    {
        double math_log_zeta_p = 0;

        if (zeta_type == "positive")
        {
            math_log_zeta_p = (Math.Log10(zeta_potential));

        }
        else if (zeta_type == "negative") { math_log_zeta_p = -(Math.Log10(zeta_potential)); }

        double math_log_steric_acid = Math.Log10(stearic_acid_concentration);

        double bracket_top = math_log_zeta_p + CONST_04_EQN_01;
        double bracket_bottom = (CONST_02_EQN_01 * math_log_steric_acid) - CONST_03_EQN_01;

        double first_bracket = Math.Pow((bracket_top / bracket_bottom), 2);
        double second_bracket = bracket_top / bracket_bottom;


        double right_side = (CONST_01_EQN_01 * first_bracket) + (CONST_05_EQN_01 * second_bracket) + (CONST_06_EQN_01);
        double answer = Math.Pow(10, right_side);

        return (int) answer;

    } // end method CalculateWetType
    

    // method CalculateWetType_Two
    public double CalculateWetType(double zeta_value)
    {
        double value_on_the_right;

        value_on_the_right = ((CONST_01_EQN_02 * Math.Pow(zeta_value, 2)) - (CONST_02_EQN_02 * zeta_value) + (CONST_03_EQN_02));

        return value_on_the_right;

    } // end method CalculateWetType_Two

    // method ShowMessage to show appropriate message based on the result
    public string ShowMessage(double theta)
    {
        string message =  String.Empty;

        WetStatus wetStatus = WetStatus.None;

        if (theta == NEUTRAL_WET)
        {
            wetStatus = WetStatus.Neutral_Wet;
        } // end if

        else
        {
            if (theta >= STRONGLY_OIL_WET_LOWER && theta <= STRONGLY_OIL_WET_UPPER)
            {
                wetStatus = WetStatus.Strongly_Wet;

            } // end if

            else if (theta >= WATER_WET_LOWER && theta <= WATER_WET_UPPER)
            {
                wetStatus = WetStatus.Water_Wet;
            } // end else if
            else if (theta <= PREFERENTIALLY_OIL_WET_UPPER && theta >= PREFERENTIALLY_OIL_WET_LOWER)
            {
                wetStatus = WetStatus.Preferentially_Oil_Wet;
            } // end else if
            else if (theta >= STRONGLY_OIL_WET_LOWER && theta <= STRONGLY_OIL_WET_UPPER)
            {
                wetStatus = WetStatus.Strongly_Oil_Wet;
            } // end else if

        } // end else


        switch (wetStatus)
        {
            case WetStatus.Strongly_Wet:
                message = "Strongly Wet";
                break;
            case WetStatus.Water_Wet:
                message = "Water Wet";
                break;
            case WetStatus.Neutral_Wet:
                message = "Neutral Wet";
                break;
            case WetStatus.Preferentially_Oil_Wet:
                message = "Preferentially Oil Wet";
                break;
            case WetStatus.Strongly_Oil_Wet:
                message = "Strongly Oil Wet";
                break;
            default:
            case WetStatus.None:
                message = "Unidentified";
                break;

        } // end switch

        return message;

    } // end method ShowMessage

} // end Class WaterStatusCalculation

