﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : ActionObject {
    public override void Trigger(string command) {
        if (command == "s")
            slot = true;
        Check(slot);
    }

    public override void Action() {
        Debug.Log("Rotate");
        StartCoroutine(RotateGear());
        Debug.Log("<color=Red>Action: </color>Rotating!!");
    }

    IEnumerator RotateGear() {
        while (true) {
            transform.Rotate(5, 0, 0);
            yield return new WaitForFixedUpdate();
        }
    }
}
