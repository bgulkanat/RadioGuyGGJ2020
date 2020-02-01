using System.Collections.Generic;
using UnityEngine;

public class SlotSystem : MonoBehaviour {
    public Slot[] slots = new Slot[4];
    public List<ActionObject> actionObjects;

    public void CheckAll() {
        string lo="";
        for (int i = 0; i < slots.Length; i++) {
            lo += slots[i].isFull;
        }
        Debug.Log(lo);
        TriggerObject(slots[0].isFull && slots[1].isFull, actionObjects[0]);
        TriggerObject(slots[0].isFull/* && slots[2].isFull*/, actionObjects[1]);
        TriggerObject(slots[0].isFull && slots[3].isFull, actionObjects[2]);
    }

    public void TriggerObject(bool condition, ActionObject action) {
        Debug.Log(action.name + ", " + condition);
        if(condition)
            action.Trigger("s+");
        else
            action.Trigger("s-");
    }
}
