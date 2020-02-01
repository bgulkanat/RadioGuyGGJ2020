using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : ActionObject
{
    public bool cable;
    public override void Trigger(string command) {
        switch (command) {
            case "s+":
                slot = true;
                break;
            case "s-":
                slot = false;
                break;
            case "c+":
                cable = true;
                break;
            case "c-":
                cable = false;
                break;

        }
        Action();
    }

    public override void Action() {
        if (slot && cable) {
            StartCoroutine(RotateGear());
            Debug.Log("<color=Red>Action: </color>Rotating!!");
        }
    }

    IEnumerator RotateGear() {
        while (slot && cable) {
            transform.Rotate(0, 1, 0);
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("<color=Red>Action: </color>Stopped!!");
    }
}
