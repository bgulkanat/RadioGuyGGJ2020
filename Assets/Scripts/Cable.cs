using UnityEngine;

public class Cable : MonoBehaviour {
    public bool isFixed;
    public CableSystem cableSystem { get => GameObject.FindGameObjectWithTag("Manager").GetComponent<CableSystem>(); }
    public Animator animator { get => GetComponent<Animator>(); }

    public void OnFixed() {
        isFixed = true;
        animator.SetBool("Fix", true);
        cableSystem.Action();
        Debug.Log(string.Format("<color=grey>Cable: </color> {0} is fixed", gameObject.name));
    }

    public void OnBroke() {
        isFixed = false;
        cableSystem.Action();
        animator.SetBool("Fix", false);
        Debug.Log(string.Format("<color=grey>Cable: </color> {0} is broked", gameObject.name));
    }
}
