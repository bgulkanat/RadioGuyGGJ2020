using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSystem : MonoBehaviour
{
    public bool[] cables;
    public ActionObject actionObject;
    public bool Check {
        get {
            foreach (var cable in cables)
                if (!cable) return false;
            return true;
        }
    } 

    public void Action() {
        if (Check)
            actionObject.Trigger("c+");
        else
            actionObject.Trigger("c-");
    }
}
