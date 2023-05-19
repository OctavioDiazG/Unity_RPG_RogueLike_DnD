using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemAsset : ScriptableObject
{
    [SerializeField] private string m_Name;
    [SerializeField] private string m_Type;
    [SerializeField] private int m_MaxStack;
    [SerializeField] private Sprite m_Icon;

    public string Name { get => m_Name; }
    public string Type { get => m_Type; }
    public int MaxStack { get => m_MaxStack; }
    public Sprite Icon { get => m_Icon; }
}
