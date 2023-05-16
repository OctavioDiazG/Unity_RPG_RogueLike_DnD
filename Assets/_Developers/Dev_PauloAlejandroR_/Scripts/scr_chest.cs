using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_chest : scr_interactables, IRollable
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("cofre");
        Debug.Log(Roll(20));
    }

    public int Roll(int diceType)
    {
        int rand = Random.Range(1, diceType);

        

        return rand;
    }
}
