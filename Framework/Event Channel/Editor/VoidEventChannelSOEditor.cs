using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(VoidEventChannelSO))]
public class VoidEventChannelSOEditor : Editor
{
    private VoidEventChannelSO eventChannel;

    private Label listenerLabel;
    private ListView listenerListView;
    private Button raiseEventButton;

    private void OnEnable()
    {
        if (this.eventChannel != null)
            this.eventChannel = target as VoidEventChannelSO;
    }

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        // Draw default elements in the inspector
        InspectorElement.FillDefaultInspector(root, serializedObject, this);

        var spaceElement = new VisualElement();
        spaceElement.style.marginBottom = 20;
        root.Add(spaceElement);

        // Add a label
        this.listenerLabel = new Label();
        this.listenerLabel.text = "Listeners:";
        this.listenerLabel.style.borderBottomWidth = 1;
        this.listenerLabel.style.borderBottomColor = Color.grey;
        this.listenerLabel.style.marginBottom = 2;
        root.Add(this.listenerLabel);

        // Add a ListView to show Listeners
        this.listenerListView = new ListView(GetListeners(), 20, MakeItem, BindItem);
        root.Add(this.listenerListView);

        // Button to test event
        this.raiseEventButton = new Button();
        this.raiseEventButton.text = "Raise Event";
        this.raiseEventButton.RegisterCallback<ClickEvent>(evt => eventChannel.RaiseEvent());
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
        //if (m_RuntimeSet.Items.Count == 0)
        //    return;
        List<MonoBehaviour> listeners = GetListeners();

        var item = listeners[index];

        Label label = (Label)element.ElementAt(0);
        label.text = GetListenerName(item);

        // Attach a ClickEvent to the label
        label.RegisterCallback<MouseDownEvent>(evt =>
        {
            // Ping the item in the Hierarchy
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

        // Get all delegates subscribed to the OnEventRaised action
        var delegateSubscribers = this.eventChannel.OnEventRaised.GetInvocationList();

        foreach (var subscriber in delegateSubscribers)
        {
            // Get the MonoBehaviour associated with each delegate
            var componentListener = subscriber.Target as MonoBehaviour;

            // Append to the list and return
            if (!listeners.Contains(componentListener))
            {
                listeners.Add(componentListener);
            }
        }

        return listeners;
    }
}
