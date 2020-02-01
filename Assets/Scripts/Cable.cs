using UnityEngine;

public class Cable : MonoBehaviour {
    public bool isFixed;
    public CableSystem cableSystem { get => GameObject.FindGameObjectWithTag("Manager").GetComponent<CableSystem>(); }

    public void OnFixed() {
        isFixed = true;
        transform.position += Vector3.down;
        cableSystem.Action();
        Debug.Log(string.Format("<color=grey>Cable: </color> {0} is fixed", gameObject.name));
    }

    public void OnBroke() {
        isFixed = false;
        cableSystem.Action();
        transform.position += Vector3.up;
        Debug.Log(string.Format("<color=grey>Cable: </color> {0} is broked", gameObject.name));
    }
}
