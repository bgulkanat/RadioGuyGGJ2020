using UnityEngine;

public class PortableObject : MonoBehaviour {
    public bool isPlaced = false;
    public Slot placedSlot;

    public void Place(Slot slot) {
        isPlaced = true;
        placedSlot = slot;
        placedSlot.OnPlace();
        Debug.Log(string.Format("<color=magenta>Portable: </color>Portable Placed to {0}", placedSlot.name));
    }
    
    public void Unplace() {
        isPlaced = false;
        placedSlot.OnUnplace();
        Debug.Log(string.Format("<color=magenta>Portable: </color>Portable unplaced from {0}", placedSlot.name));

        placedSlot = null;
    }
}
