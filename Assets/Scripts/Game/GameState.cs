using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public UIHandler uiHandler { get => GetComponent<UIHandler>(); }
    public CableSystem cableSystem { get => GetComponent<CableSystem>(); }
    [Header("Rage")]
    public bool rageOn = false;
    public bool isRageIncreasing;
    public float rage;
    public float maxRage;
    public float rageIncreaseMultiplier;
    public float rageDecreaseMultiplier;

    [Header("Cable")]
    public float breakTimer;
    public float timer;
    public int breakStep;
    public int sequenceSteps;

    public void StartRage() {
        uiHandler.SetMaxRage(maxRage);
        StartCoroutine(BreakSequence());
        rageOn = true;
    }

    private void Update() {
        if (rageOn) {
            if (isRageIncreasing)
                rage += Mathf.Clamp(rageIncreaseMultiplier, 0, maxRage) * Time.deltaTime;
            else
                rage += Mathf.Clamp(rageDecreaseMultiplier, 0, maxRage) * Time.deltaTime;

            uiHandler.SetRage(rage);

            timer -= Time.deltaTime;
            if (timer < breakTimer) {
                BreakSequence();
            }



            if (rage >= maxRage)
                GameOver();
        }
    }

    void BreakSequence() {
        if (breakStep < sequenceSteps) {
            cableSystem.BreakSequence(breakStep);
            breakStep++;
        }
        else {
            breakTimer = Mathf.Lerp(breakTimer, 10, Time.fixedDeltaTime);
            Debug.Log(breakTimer);
        }
    }

    private void GameOver() {
        uiHandler.GameOver();
        rageOn = false;
    }
}
