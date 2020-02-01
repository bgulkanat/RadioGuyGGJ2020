using System.Collections.Generic;
using UnityEngine;

public class SlotSystem : MonoBehaviour {
    public Slot[] slots = new Slot[4];
    public List<ActionObject> actionObjects;

    public void CheckAll() {
        TriggerObject(slots[0].isFull && slots[1].isFull, actionObjects[0]);
        TriggerObject(slots[0].isFull && slots[2].isFull, actionObjects[1]);
        TriggerObject(slots[0].isFull && slots[3].isFull, actionObjects[2]);
    }

    public void TriggerObject(bool condition, ActionObject action) {
        Debug.Log(string.Format("<color=Red>{0}</color> is {1}", action.name, condition));
        if (condition)
            action.Trigger("s+");
        else
            action.Trigger("s-");
    }
}
