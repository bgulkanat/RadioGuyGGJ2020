using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : ActionObject
{
    public bool cable;
    public override void Trigger(string command) {
        if (command == "s")
            slot = true;
        else if (command == "c")
            cable = true;
        Check(slot, cable);
    }

    public override void Action() {
        transform.Rotate(30, 0, 0);
        Debug.Log("<color=Red>Action: </color>Rotating!!");
    }
}
