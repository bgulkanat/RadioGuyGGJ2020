﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObject : MonoBehaviour {
    public bool slot;

    public virtual void Trigger(string command) {
    }

    public virtual void Action() {
    }
}