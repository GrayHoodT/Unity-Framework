using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(GenericEventChannelSO<>), true)]
public class GenericEventChannelSOEditor<T> : Editor
{
    private GenericEventChannelSO<T> eventChannel;

    // Label and counter for items in the list
    private Label listenersLabel;
    private ListView listenersListView;
    private Button raiseEventButton;

    private void OnEnable()
    {
        if (this.eventChannel == null)
            this.eventChannel = target as GenericEventChannelSO<T>;
    }

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        InspectorElement.FillDefaultInspector(root, serializedObject, this);

        var spaceElement = new VisualElement();
        spaceElement.style.marginBottom = 20;
        root.Add(spaceElement);

        this.listenersLabel = new Label();
        this.listenersLabel.text = "Listeners:";
        this.listenersLabel.style.borderBottomWidth = 1;
        this.listenersLabel.style.borderBottomColor = Color.grey;
        this.listenersLabel.style.marginBottom = 2;
        root.Add(listenersLabel);

        this.listenersListView = new ListView(GetListeners(), 20, MakeItem, BindItem);
        root.Add(this.listenersListView);

        this.raiseEventButton = new Button();
        this.raiseEventButton.text = "Raise Event";
        this.raiseEventButton.RegisterCallback<ClickEvent>(evt => this.eventChannel.RaiseEvent(default(T)));
        this.raiseEventButton.style.marginBottom = 20;
        this.raiseEventButton.style.marginTop = 20;
        root.Add(this.raiseEventButton);

        return root;
    }

    private VisualElement MakeItem()
    {
        var element = new VisualElement();
        var label = new Label();
        element.Add(label);
        return element;
    }

    private void BindItem(VisualElement element, int index)
    {
        List<MonoBehaviour> listeners = GetListeners();

        var item = listeners[index];

        Label label = (Label)element.ElementAt(0);
        label.text = GetListenerName(item);

        label.RegisterCallback<MouseDownEvent>(evt =>
        {
            EditorGUIUtility.PingObject(item.gameObject);
        });

    }

    private string GetListenerName(MonoBehaviour listener)
    {
        if (listener == null)
            return "<null>";

        string combinedName = listener.gameObject.name + " (" + listener.GetType().Name + ")";
        return combinedName;

    }

    private List<MonoBehaviour> GetListeners()
    {
        List<MonoBehaviour> listeners = new List<MonoBehaviour>();

        if (this.eventChannel == null || this.eventChannel.OnEventRaised == null)
            return listeners;

        var delegateSubscribers = this.eventChannel.OnEventRaised.GetInvocationList();

        foreach (var subscriber in delegateSubscribers)
        {
            var componentListener = subscriber.Target as MonoBehaviour;

            if (!listeners.Contains(componentListener))
                listeners.Add(componentListener);
        }

        return listeners;
    }
}
