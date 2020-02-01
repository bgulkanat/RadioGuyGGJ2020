using UnityEngine;

public class Interaction : MonoBehaviour {
    public float maxHitDistance = 100;

    public LayerMask portableObject;
    public LayerMask slot;
    public LayerMask cableLayer;

    public Transform objectContainer { get => transform.GetChild(2); }
    public Transform carriedObject;
    public Transform raySource;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            
            var cable = Target(cableLayer);
            if (cable != null)
                cable.GetComponent<Cable>().OnFixed();
            else if (carriedObject == null) {
                var target = Target(portableObject);
                if (target != null)
                    HoldObject(target);
            }
            else {
                var slotTarget = Target(slot);
                if (slotTarget != null && !slotTarget.GetComponent<Slot>().isFull)
                    PlaceObject(slotTarget);
            }
        }
    }

    // Nesneyi tut
    public void HoldObject(Transform target) {
        carriedObject = target;
        carriedObject.SetParent(objectContainer);
        carriedObject.transform.localPosition = Vector3.zero;
        carriedObject.transform.localScale /= 4;
        if (carriedObject.GetComponent<PortableObject>().isPlaced)
            carriedObject.GetComponent<PortableObject>().Unplace();
        Debug.Log("<color=Green>Carrier: </color>Hold the " + target.name);
    }

    // Nesneyi slota yerleştir
    public void PlaceObject(Transform target) {
        carriedObject.SetParent(target);
        carriedObject.transform.localPosition = Vector3.zero;
        carriedObject.transform.localScale *= 4;
        Debug.Log(string.Format("<color=Green>Carrier: </color>Place the <color=magenta>{0}</color> to the <color=Blue>{1}</color>"
            , carriedObject.name, target.name));


        carriedObject.GetComponent<PortableObject>().Place(target.GetComponent<Slot>());
        carriedObject = null;
    }

    public Transform Target(LayerMask layer) {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(raySource.position, raySource.TransformDirection(Vector3.forward), out hit, maxHitDistance, layer)) {
            Debug.DrawRay(raySource.position, raySource.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("<color=cyan>Raycast: </color>Hit on: " + hit.collider.gameObject.name);
            return hit.collider.gameObject.transform;
        }
        else {
            Debug.DrawRay(raySource.position, raySource.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("<color=cyan>Raycast: </color>Did not Hit");
            return null;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("<color=gray>Raycast: </color> collide with " + other.name);
        if (other.gameObject.layer == 9 && !other.gameObject.GetComponent<Slot>().isFull)
            PlaceObject(other.gameObject.transform);
    }
}
