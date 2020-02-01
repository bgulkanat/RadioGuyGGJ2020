using System.Collections.Generic;
using UnityEngine;

public class SlotSystem : MonoBehaviour {
    public bool[] slots = new bool[4];
    public List<ActionObject> actionObjects;

    public void CheckAll() {
        if (slots[0] && slots[1])
            actionObjects[0].Trigger("s+");
        else
            actionObjects[0].Trigger("s-");

        if (slots[0] && slots[2])
            actionObjects[1].Trigger("s+");
        else
            actionObjects[1].Trigger("s-");
    }

    public void ChangeSlotCondition(int slotID, bool condition) {
        slots[slotID] = condition;
        CheckAll();
    }
}
