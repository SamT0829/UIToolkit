using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HomeScreen : MenuScreen
{
    public static event Action PlayButtonClicked;
    public static event Action HomeScreenShown;

    private const string k_playLevelButtonName = "home-play__level-button";
    private VisualElement m_playLevelButton;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        // m_playLevelButton = m_Root.Q(k_playLevelButtonName);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        m_playLevelButton.RegisterCallback<ClickEvent>(ClickPlayButton);
    }

    private void ClickPlayButton(ClickEvent evt)
    {
        // AudioManager.PlayDefaultButtonSound();
        PlayButtonClicked?.Invoke();
    }
}