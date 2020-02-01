using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : ActionObject {

    public float rotateSpeed = 1;
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
        if (slot)
            OnStart();
    }

    public override void OnStart() {
        StartCoroutine(RotateGear());
        Debug.Log("<color=Red>Action: </color>Rotating!!");
    }
    public override void OnStop() {
        Debug.Log("<color=Red>Action: </color>Stopped!!");
    }
    IEnumerator RotateGear() {
        while (slot) {
            transform.Rotate(0, rotateSpeed, 0);
            yield return new WaitForFixedUpdate();
        }
        OnStop();
    }
}
