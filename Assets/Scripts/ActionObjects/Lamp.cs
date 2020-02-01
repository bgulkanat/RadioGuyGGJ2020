using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : ActionObject
{
    public bool cable;
    public GameState gameState { get => GameObject.FindGameObjectWithTag("Manager").GetComponent<GameState>(); }
    
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
        if (slot/* && cable*/) {
            OnStart();
        }
    }

    public override void OnStop() {
        Debug.Log("<color=Red>Action: </color>Lamp off!!");
    }
    public override void OnStart() {
        gameState.StartRage();
        Debug.Log("<color=Red>Action: </color>Lamp on!!");
    }

}
