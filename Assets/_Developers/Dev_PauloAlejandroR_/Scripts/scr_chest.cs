using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_chest : scr_interactables, IRollable
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("cofre");
        Roll(20);
    }
   
    public void Roll(int diceType)
    {
        int rand = Random.Range(1, diceType);

        StartCoroutine(scr_diceRoll.RollAnimCoroutine(diceType, rand, this));
    }

    public override void resultBehaviour(int result)
    {
        Debug.Log(result);
    }

}
