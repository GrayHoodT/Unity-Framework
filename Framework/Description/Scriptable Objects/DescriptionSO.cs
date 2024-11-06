using UnityEngine;

public abstract class DescriptionSO : ScriptableObject
{
    [TextArea(5, 20)]
    [SerializeField] protected string description;
}
