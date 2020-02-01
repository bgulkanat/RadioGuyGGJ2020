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
    public float rageIncreaseSpeed = 1;
    public float rageDecreaseSpeed = 1;

    [Header("Cable")]
    public float breakTimer;
    public float timer;
    public int breakStep;
    public int sequenceSteps;

    public void StartRage() {
        uiHandler.SetMaxRage(maxRage);
        rageOn = true;
    }

    private void Update() {
        if (rageOn) {
            isRageIncreasing = !cableSystem.Check;

            if (isRageIncreasing)
                rage = Mathf.Clamp(rage += rageIncreaseSpeed * Time.deltaTime, 0, maxRage) ;
            else {
                rage = Mathf.Clamp(rage -= rageDecreaseSpeed * Time.deltaTime, 0, maxRage);

                timer -= Time.deltaTime;
                if (timer <= 0 && cableSystem.Check)
                    BreakSequence();
            }
            uiHandler.SetRage(rage);

            if (rage >= maxRage)
                GameOver();
        }
    }

    void BreakSequence() {
        timer = breakTimer;
        if (breakStep < sequenceSteps) {
            cableSystem.BreakSequence(breakStep);
            breakStep++;
        }
        else {
            cableSystem.Break((int)UnityEngine.Random.Range(0, 4));
            breakTimer = Mathf.Lerp(breakTimer, 10, Time.fixedDeltaTime);
            Debug.Log(breakTimer);
        }
        isRageIncreasing = true;
    }

    private void GameOver() {
        uiHandler.GameOver();
        rageOn = false;
    }
}
