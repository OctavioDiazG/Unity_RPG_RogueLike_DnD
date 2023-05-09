using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerInteraction : MonoBehaviour
{
    [SerializeField]private List<GameObject> interactableList;
    private PlayerInputManager playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        if (playerInput.wantsToInteract)
        {
            playerInput.wantsToInteract = false;
            Interact();
        }
    }

    public void addInteractable(GameObject newInteractable)
    {
        interactableList.Add(newInteractable);
    }

    public void removeInteractable(GameObject m_interactable)
    {
        interactableList.Remove(m_interactable);
    }

    private void Interact()
    {
        if (interactableList.Count == 0)
        {
            return;
        }

        interactableList[interactableList.Count-1].GetComponent<scr_interactables>().Interact();
        removeInteractable(interactableList[interactableList.Count - 1]);
    }
}
