using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bass : ActionObject
{
    public BoxCollider bassArea { get => GetComponent<BoxCollider>(); }
    public Animator animator { get => GetComponent<Animator>(); }
    public override void Trigger(string command) {
        switch (command) {
            case "s+":
                slot = true;
                break;
            case "s-":
                slot = false;
                break;
        }
        Action();
    }

    public override void Action() {
        if (slot) {
            bassArea.enabled = true;
            if (animator != null)
                animator.SetBool("Boom", true);
            Debug.Log("<color=Red>Action: </color>Bass On!!");
        }
        else if (bassArea.enabled){
            bassArea.enabled = false;
            if (animator != null)
                animator.SetBool("Boom", false);
            Debug.Log("<color=Red>Action: </color>Bass Off!!");
        }
    }

}
