using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_chest : scr_interactables
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("cofre");
    }
}
