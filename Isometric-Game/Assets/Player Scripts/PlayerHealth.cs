using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;



    public void setMaxHealth(int health){
        healthSlider.maxValue = health;
        healthSlider.value = health;
        fill.color = gradient.Evaluate(1f);

    }


    public void setHealth(int health){
        healthSlider.value = health;

        fill.color = gradient.Evaluate(healthSlider.normalizedValue);

    }
}
