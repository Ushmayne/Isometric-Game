using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider manaSlider;
    public Gradient gradient;
    public Image fill;



    public void setMaxMana(int health){
        manaSlider.maxValue = health;
        manaSlider.value = health;
        fill.color = gradient.Evaluate(1f);

    }


    public void setMana(int health){
        manaSlider.value = health;

        fill.color = gradient.Evaluate(manaSlider.normalizedValue);

    }
}
