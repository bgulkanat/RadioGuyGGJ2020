using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : ActionObject
{
    public override void Trigger(string command) {
        if (command == "s")
            slot = true;
        Check();
    }

    public override void Action() {
        transform.Rotate(30, 0, 0);
        Debug.Log("<color=Red>Action: </color>Rotating!!");
    }
}
