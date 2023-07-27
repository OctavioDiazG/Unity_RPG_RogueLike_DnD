using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_diceRoll : MonoBehaviour
{
    public static IEnumerator RollAnimCoroutine(int diceType, int result, scr_interactables interactingObject)
    {
        //Aqui ocurre la Anim
        yield return new WaitForSeconds(2);
        interactingObject.resultBehaviour(result);
    }
}
