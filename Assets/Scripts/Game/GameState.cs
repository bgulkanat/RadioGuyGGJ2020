using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public UIHandler uiHandler { get => gameObject.GetComponent<UIHandler>(); }

    [Header("Rage")]
    public bool rageOn=false;
    public bool isIncreasing;
    public float rage;
    public float maxRage;
    public float rageIncreasingMultiplier = 1;
    public float rageDecreasingMultiplier = -2;


    public void StartRage() {
        uiHandler.SetMaxRage(maxRage);
        rageOn = true;
    }

    private void Update() {
        if (rageOn) {
            if (isIncreasing)
                rage += Mathf.Clamp(rageIncreasingMultiplier * Time.deltaTime, 0, maxRage);
            else
                rage += Mathf.Clamp(rageIncreasingMultiplier * Time.deltaTime, 0, maxRage);

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
