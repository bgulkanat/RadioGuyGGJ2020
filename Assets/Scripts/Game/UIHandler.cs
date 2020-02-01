using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Slider rageSlider;

    public void SetRage(float rageAmount) {
        rageSlider.value = rageAmount;
    }

    public void GameOver() {
        
    }

    internal void SetMaxRage(float maxRage) {
        rageSlider.maxValue = maxRage;
    }
}
