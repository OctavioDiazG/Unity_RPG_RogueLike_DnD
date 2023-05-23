using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class scr_interactables : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("xd");
            other.GetComponent<scr_playerInteraction>().addInteractable(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("xdnt");
            other.GetComponent<scr_playerInteraction>().removeInteractable(gameObject);
        }
    }

    public virtual void Interact()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    public abstract void resultBehaviour(int result);
}
