using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bass : ActionObject
{
    public BoxCollider boxCollider { get => GetComponent<BoxCollider>(); }
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
            Debug.Log("<color=Red>Action: </color>Bass On!!");
        }
        else {
            Debug.Log("<color=Red>Action: </color>Bass Off!!");
        }
    }

}
