using UnityEngine;

public class Cable : MonoBehaviour {
    public int cableId;
    public CableSystem cableSystem { get => GameObject.FindGameObjectWithTag("Manager").GetComponent<CableSystem>(); }

    public void OnFixed() {
        cableSystem.cables[cableId] = true;
        cableSystem.Action();
        Debug.Log(string.Format("<color=grey>Cable: </color> {0} is fixed", gameObject.name));
    }
}
