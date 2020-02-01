using UnityEngine;

public class Cable : MonoBehaviour {
    public bool isFixed;
    public ActionObject actionObject;

    public void OnFixed() {
        isFixed = true;
        actionObject.Trigger("c");
        Debug.Log("<color=grey>Cable: </color> is fixed");
    }
}
