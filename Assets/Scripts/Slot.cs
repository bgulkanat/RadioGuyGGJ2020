using UnityEngine;

public class Slot : MonoBehaviour {
    public bool isFull=false;
    public int slotID;
    public SlotSystem slotSystem;

    private void Awake() {
        slotSystem = GameObject.FindGameObjectWithTag("SlotSystem").GetComponent<SlotSystem>();
    }

    public void OnPlace() {
        isFull = true;
        slotSystem.slots[slotID] = isFull;
        Debug.Log("Slot filled");
    }

    public void OnUnplace() {
        isFull = false;
        slotSystem.slots[slotID] = isFull;
        Debug.Log("Slot emptied");
    }
}