using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIElementsRaycast : MonoBehaviour, IFactory<RaycastResult[]>
{
    [SerializeField] private GraphicRaycaster m_Raycaster;

    private PointerEventData pointerData;
    private EventSystem eventSystem;

    private void Awake()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    public RaycastResult[] Create()
    {
        pointerData = new PointerEventData(eventSystem);
        pointerData.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new();
        m_Raycaster.Raycast(pointerData, results);
        return results.ToArray();
    }
}
