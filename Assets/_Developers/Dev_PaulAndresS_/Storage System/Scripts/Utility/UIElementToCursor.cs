using UnityEngine;
using UnityEngine.InputSystem;

public class UIElementToCursor : MonoBehaviour
{
    [SerializeField] private RectTransform m_Element;

    private void Update()
    {
        m_Element.position = Mouse.current.position.ReadValue();
    }
}