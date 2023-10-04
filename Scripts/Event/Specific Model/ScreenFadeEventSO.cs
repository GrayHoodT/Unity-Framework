namespace GrayHoodT.Events
{
    using GrayHoodT.Structs;
    using UnityEngine;

    [CreateAssetMenu(fileName = "FadeEventSO", menuName = "Scriptable Object/Event/Specific/Screen Fade")]
    public sealed class ScreenFadeEventSO : EventSO<ScreenFadeMessage> { }
}

