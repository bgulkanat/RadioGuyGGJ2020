using System.Collections.Generic;
using UnityEngine;

public class SlotSystem : MonoBehaviour {
    public bool[] slots = new bool[4];
    public List<ActionObject> actionObjects;

    public void CheckAll() {

        TriggerObject(slots[0] && slots[1], actionObjects[0]);
        TriggerObject(slots[0] && slots[2], actionObjects[1]);
        TriggerObject(slots[0] && slots[3], actionObjects[2]);
    }

    public void TriggerObject(bool condition, ActionObject action) {
        if(condition)
            action.Trigger("s+");
        else
            action.Trigger("s-");
    }

    public void ChangeSlotCondition(int slotID, bool condition) {
        slots[slotID] = condition;
        CheckAll();
    }
}
