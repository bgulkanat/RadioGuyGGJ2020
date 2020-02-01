using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public UIHandler uiHandler { get => gameObject.GetComponent<UIHandler>(); }

    [Header("Rage")]
    public bool rageOn=false;
    public float rage;
    public float maxRage;
    public float rageMultiplier = 1;

    public void StartRage() {
        uiHandler.SetMaxRage(maxRage);
        rageOn = true;
    }

    private void Update() {
        if (rageOn) {
            rage += rageMultiplier * Time.deltaTime;
            rage = Mathf.Clamp(rage, 0, maxRage);
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
