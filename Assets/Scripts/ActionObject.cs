using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObject : MonoBehaviour {
    public bool slot;

    public virtual void Trigger(string command) {
    }

    public virtual bool Check(params bool[] keys) {
        foreach (var i in keys) {
            if (!i) return false;
        }
        return true;
    }

    public virtual void Action() {}
}