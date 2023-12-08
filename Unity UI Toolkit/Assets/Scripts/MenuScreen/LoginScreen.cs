using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoginScreen : MenuScreen
{
    public static event Action<string, string> LoginButtonClicked;
    public static event Action LoginScreenShown;

    private const string k_accountTextFieldName = "Account-TextField";
    private const string k_passwordTextFieldName = "Password-TextField";
    private const string k_loginButtonName = "Login-Button";

    private TextField m_accountTextField;
    private TextField m_passwordTextField;  
    private Button m_loginButton;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_accountTextField = m_Root.Q<TextField>(k_accountTextFieldName);
        m_passwordTextField = m_Root.Q<TextField>(k_passwordTextFieldName);
        m_loginButton = m_Root.Q<Button>(k_loginButtonName);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        m_loginButton.RegisterCallback<ClickEvent>(ClickLoginButton);
    }

    private void ClickLoginButton(ClickEvent evt)
    {
        string account = m_accountTextField?.value;
        string password = m_passwordTextField?.value;
        LoginButtonClicked?.Invoke(account, password);
    }

    public override void ShowScreen()
    {
        base.ShowScreen();
        LoginScreenShown?.Invoke();
    }
}
