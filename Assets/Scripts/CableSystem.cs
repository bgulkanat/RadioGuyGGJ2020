using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSystem : MonoBehaviour
{
    public Cable[] cables;
    public ActionObject actionObject;

    public float breakTimer;
    public int breakStep;
    public int sequenceSteps;

    private void Start() {
        StartCoroutine(BrakeSequence());
    }

    public bool Check {
        get {
            foreach (var cable in cables)
                if (!cable.isFixed) return false;
            return true;
        }
    } 

    public void Action() {
        if (Check)
            actionObject.Trigger("c+");
        else
            actionObject.Trigger("c-");
    }

    IEnumerator BrakeSequence() {
        while (true) {
            if (breakStep < sequenceSteps)
                switch (breakStep) {
                    case 0:
                        Brake(cables[0]);
                        break;
                    default:
                        break;
                }
            else {
                breakTimer = Mathf.Lerp(breakTimer, 10, Time.fixedDeltaTime);
                Debug.Log(breakTimer);

            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void Brake(params Cable[] cablesToBroke) {
        foreach(var cable in cablesToBroke) {
            cable.OnBroke();
        }
        breakStep++;
    }
}
