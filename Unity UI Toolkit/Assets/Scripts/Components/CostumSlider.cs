using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class CostumSlider : MonoBehaviour
{
    private VisualElement m_root;
    private VisualElement m_slider;
    private VisualElement m_dragger;
    private VisualElement m_bar;
    private VisualElement m_newDragger;
    private VisualElement m_bubble;
    private Label m_bubbleLabel;

    [SerializeField] private Color colorA;
    [SerializeField] private Color colorB;

    void Start()
    {
        m_root = GetComponent<UIDocument>().rootVisualElement;
        m_slider = m_root.Q<Slider>("MySlider");
        m_dragger = m_root.Q<VisualElement>("unity-dragger");

        AddElement();

        //When the slider's value changes
        m_slider.RegisterCallback<ChangeEvent<float>>(SliderValueChange);

        //When the slider's ;ayout is calculated
        m_slider.RegisterCallback<GeometryChangedEvent>(SliderInit);

        //When the pointer is captured
        m_slider.RegisterCallback<PointerCaptureEvent>(_ => m_bubble.RemoveFromClassList("bubble-hidden"));

        //When the pointer is captured
        m_slider.RegisterCallback<PointerCaptureOutEvent>(_ => m_bubble.AddToClassList("bubble-hidden"));
    }

    private void AddElement()
    {
        m_bar = new VisualElement();
        m_dragger.Add(m_bar);
        m_bar.name = "Bar";
        m_bar.AddToClassList("bar");

        m_newDragger = new VisualElement();
        m_slider.Add(m_newDragger);
        m_newDragger.name = "NewDragger";
        m_newDragger.AddToClassList("newdragger");
        m_newDragger.pickingMode = PickingMode.Ignore;

        m_bubble = new VisualElement();
        m_slider.Add(m_bubble);
        m_bubble.AddToClassList("bubble");
        m_bubble.AddToClassList("bubble-hidden");
        m_bubble.pickingMode = PickingMode.Ignore;

        m_bubbleLabel = new Label();
        m_bubble.Add(m_bubbleLabel);
        m_bubbleLabel.AddToClassList("bubble_label");
        m_bubbleLabel.pickingMode = PickingMode.Ignore;
    }

    private void SliderValueChange(ChangeEvent<float> value)
    {
        Vector2 offset = new Vector2((m_newDragger.layout.width - m_dragger.layout.width) / 2, (m_newDragger.layout.height - m_dragger.layout.height) / 2);
        Vector2 offsetBubble = new Vector2((m_bubble.layout.width - m_dragger.layout.width) / 2, (m_bubble.layout.height - m_dragger.layout.height) / 2 + 100f);
        Vector2 pos = m_dragger.parent.LocalToWorld(m_dragger.transform.position);
        pos = m_newDragger.parent.WorldToLocal(pos);

        m_newDragger.transform.position = pos - offset;
        m_bubble.transform.position = pos - offsetBubble;

        float v = Mathf.Round(value.newValue);

        m_bubbleLabel.text = v.ToString();
        // m_bubbleLabel.style.color = Color.white;

        //Color Interpolatiom
        m_bar.style.unityBackgroundImageTintColor = Color.Lerp(colorA, colorB, v / 100f);
        m_bubble.style.unityBackgroundImageTintColor = Color.Lerp(colorA, colorB, v / 100f);
    }

    private void SliderInit(GeometryChangedEvent value)
    {
        Vector2 offset = new Vector2((m_newDragger.layout.width - m_dragger.layout.width) / 2, (m_newDragger.layout.height - m_dragger.layout.height) / 2);
        Vector2 offsetBubble = new Vector2((m_bubble.layout.width - m_dragger.layout.width) / 2, (m_bubble.layout.height - m_dragger.layout.height) / 2 + 100f);
        Vector2 pos = m_dragger.parent.LocalToWorld(m_dragger.transform.position);
        pos = m_newDragger.parent.WorldToLocal(pos);

        m_newDragger.transform.position = pos - offset;
        m_bubble.transform.position = pos - offsetBubble;

        //Color Interpolatiom
        m_bar.style.unityBackgroundImageTintColor = colorA;
        m_bubble.style.unityBackgroundImageTintColor = colorA;
    }
}
