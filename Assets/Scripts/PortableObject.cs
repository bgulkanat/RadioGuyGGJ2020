using UnityEngine;

public class PortableObject : MonoBehaviour {
    public bool isPlaced = false;
    public Slot placedSlot;

    public void Place(Slot slot) {
        isPlaced = true;
        placedSlot = slot;
        placedSlot.OnPlace();
        Debug.Log(string.Format("Portable Placed to {0}", placedSlot.name));
    }

    public void Unplace() {
        isPlaced = false;
        placedSlot.OnUnplace();
        Debug.Log(string.Format("Portable unplaced from {0}", placedSlot.name));

        placedSlot = null;
    }
}
