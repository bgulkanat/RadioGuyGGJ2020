using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public UIHandler uiHandler { get => gameObject.GetComponent<UIHandler>(); }

    [Header("Rage")]
    public bool rageOn=false;
    public bool isRageIncreasing;
    public float rage;
    public float maxRage;
    public float rageIncreaseMultiplier;
    public float rageDecreaseMultiplier;

    public void StartRage() {
        uiHandler.SetMaxRage(maxRage);
        rageOn = true;
    }

    private void Update() {
        if (rageOn) {
            if (isRageIncreasing)
                rage += Mathf.Clamp(rageIncreaseMultiplier, 0, maxRage) * Time.deltaTime;
            else
                rage += Mathf.Clamp(rageDecreaseMultiplier, 0, maxRage) * Time.deltaTime;

            uiHandler.SetRage(rage);
        if (rage >= maxRage)
                GameOver();
        }
    }

    private void GameOver() {
        uiHandler.GameOver();
        rageOn = false;
    }
}
