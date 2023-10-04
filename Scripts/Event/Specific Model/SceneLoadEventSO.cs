namespace GrayHoodT.Events
{
    using GrayHoodT.Structs;
    using UnityEngine;

    [CreateAssetMenu(fileName = "SceneLoadEventSO", menuName = "Scriptable Object/Event/Specific/Scene Load")]
    public sealed class SceneLoadEventSO : EventSO<SceneLoadMessage[]> { }
}
