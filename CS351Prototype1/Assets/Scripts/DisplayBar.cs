using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Must include this for slider^

public class DisplayBar : MonoBehaviour
{
    //refernce to slider for health bar
    public Slider slider;

    //Function to set current value of slider
    public void SetValue(float value)
    {
        //set value to current value of slider
        slider.value = value;
    }

    //function to set max value of slider
    public void SetMaxValue(float value)
    {
        //set max value of slider
        slider.maxValue = value;

        //set current value of slider to the max value
        slider.value = value;
    }
}