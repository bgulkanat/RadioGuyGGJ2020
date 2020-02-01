using System.Collections.Generic;
using UnityEngine;

public class SlotSystem : MonoBehaviour {
    public Slot[] slots = new Slot[4];
    public List<ActionObject> actionObjects;

    public void CheckAll() {

        TriggerObject(slots[0] && slots[1], actionObjects[0]);
        TriggerObject(slots[0] && slots[2], actionObjects[1]);
        TriggerObject(slots[0] && slots[3], actionObjects[2]);
    }

    public void TriggerObject(bool condition, ActionObject action) {
        Debug.Log(action.name + ", " + condition);
        if(condition)
            action.Trigger("s+");
        else
            action.Trigger("s-");
    }
}
