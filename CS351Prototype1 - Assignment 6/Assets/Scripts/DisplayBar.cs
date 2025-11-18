using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Must include this for slider^

public class DisplayBar : MonoBehaviour
{
    //refernce to slider for health bar
    public Slider slider;

    //gradient for healthbar
    public Gradient gradient;

    //image fir the fill of the health bar
    public Image fill;

    //Function to set current value of slider
    public void SetValue(float value)
    {
        //set value to current value of slider
        slider.value = value;

        //set the color of the fill of the slider
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    //function to set max value of slider
    public void SetMaxValue(float value)
    {
        //set max value of slider
        slider.maxValue = value;

        //set current value of slider to the max value
        slider.value = value;

        //Set the color of the fill of the slider
        fill.color = gradient.Evaluate(1f);
    }
}