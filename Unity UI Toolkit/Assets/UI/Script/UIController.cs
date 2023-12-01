using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    private VisualElement m_buttomContainer;
    private Button m_openButton;
    private Button m_closeButton;

    private VisualElement m_bottomSheet;
    private VisualElement m_scrim;

    private VisualElement m_boy;
    private VisualElement m_girl;

    private Label m_message;

    private const string k_bottomsheet_up = "bottomsheet-up";


    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        m_buttomContainer = root.Q<VisualElement>("Container_Bottom");
        m_buttomContainer.style.display = DisplayStyle.None;

        m_openButton = root.Q<Button>("Button_Open");
        m_closeButton = root.Q<Button>("Button_Close");

        m_bottomSheet = root.Q<VisualElement>("BottomSheet");
        m_scrim = root.Q<VisualElement>("Scrim");

        m_girl = root.Q<VisualElement>("Image_Girl");

        m_message = root.Q<Label>("Message");

        m_openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        m_closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);

    }

    private void OnOpenButtonClicked(ClickEvent evt)
    {
        m_buttomContainer.style.display = DisplayStyle.Flex;

        m_bottomSheet.AddToClassList(k_bottomsheet_up);
        m_scrim.AddToClassList("scrim-fadein");

        AnimateGirl();
    }

    private void AnimateGirl()
    {
        m_girl.ToggleInClassList("image-girl-up");
        m_girl.RegisterCallback<TransitionEndEvent>(e => m_girl.ToggleInClassList("image-girl-up"));

        m_message.text = string.Empty;
        string message = "I had to leave so early last night that I never heard your answer—did you grow up around here?";
        DOTween.To(() => m_message.text, x => m_message.text = x, message, 3f).SetEase(Ease.Linear).SetId(0);
    }

    private void OnCloseButtonClicked(ClickEvent evt)
    {
        m_bottomSheet.RemoveFromClassList(k_bottomsheet_up);
        m_scrim.RemoveFromClassList("scrim-fadein");
        m_bottomSheet.RegisterCallback<TransitionEndEvent>(OnBottomSheetDown);

        DOTween.Kill(0);
        m_message.text = string.Empty;
    }

    private void OnBottomSheetDown(TransitionEndEvent evt)
    {
        if (!m_bottomSheet.ClassListContains(k_bottomsheet_up))
        {
            m_buttomContainer.style.display = DisplayStyle.None;
            m_bottomSheet.UnregisterCallback<TransitionEndEvent>(OnBottomSheetDown);
        }
    }
}
