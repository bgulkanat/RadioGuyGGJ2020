using UnityEngine;

public class CableSystem : MonoBehaviour {
    public Cable[] cables;
    public ActionObject actionObject;

    public bool Check {
        get {
            foreach (var cable in cables) {
                if (!cable.isFixed) return false;
            }
            return true;
        }
    }

    public void BreakSequence(int breakStep) {
        switch (breakStep) {
            case 0:
                Break(0);
                break;
            case 1:
                Break(1);
                break;
            case 2:
                Break(0, 2);
                break;
            case 3:
                Break(3);
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

    public void Break(params int[] cablesToBroke) {
        foreach (var cable in cablesToBroke) {
            cables[cable].OnBroke();
        }
    }
}
