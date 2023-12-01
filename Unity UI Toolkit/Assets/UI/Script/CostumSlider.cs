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

    // Start is called before the first frame update
    void Start()
    {
        m_root = GetComponent<UIDocument>().rootVisualElement;
        m_slider = m_root.Q<Slider>("MySlider");
        m_dragger = m_root.Q<VisualElement>("unity-dragger");

        AddElement();
    }

    private void AddElement()
    {
        m_bar = new VisualElement();
        m_dragger.Add(m_bar);
        m_bar.name = "Bar";
        IStyle style = m_bar.style;
        style.width = 100f;
        style.height = 100f;
        style.backgroundColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
