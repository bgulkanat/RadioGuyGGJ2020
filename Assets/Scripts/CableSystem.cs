using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSystem : MonoBehaviour {
    public Cable[] cables;
    public ActionObject actionObject;


    public bool Check {
        get {
            foreach (var cable in cables) {
                Debug.Log(cable.isFixed);
                if (!cable.isFixed) return false;
            }
            return true;
        }
    }

    public void BreakSequence(int breakStep) {
        switch (breakStep) {
            case 0:
                Break(cables[0]);
                break;
            default:
                break;
        }
    }

    public void Action() {
        if (Check)
            actionObject.Trigger("c+");
        else
            actionObject.Trigger("c-");
    }

    public void Break(params Cable[] cablesToBroke) {
        foreach (var cable in cablesToBroke) {
            cable.OnBroke();
        }
    }
}
