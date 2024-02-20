using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;

public class LoginPagePlayfab : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI TopText;
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] TMP_InputField UsernameRegisterInput;
    [SerializeField] TMP_InputField EmailRegisterInput;
    [SerializeField] TMP_InputField PasswordRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] TMP_InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoverPage;

    void Update() {

    }

    void Awake() {
        PlayFabSettings.TitleId = "9148A"; //your title id goes here.
    }

    #region Buttom Functions

    public void RegisterUser() {

        // if statement if password is less than 6 message text = Too short password;

        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,

            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSuccess, OnError);
    }

    public void Login() {
        var request = new LoginWithEmailAddressRequest {
            Email = EmailLoginInput.text,
            Password = PasswordLoginInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult Result) {
        MessageText.text = "Logged in";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2); 
        //SceneManager.LoadScene("MainMenu");
    }

    public void RecoverUser() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = EmailRecoveryInput.text,
            TitleId = "9148A",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnErrorRecovery);
    }

    private void OnErrorRecovery(PlayFabError result) {
        MessageText.text = "No Email Found";
    }


    private void OnRecoverySuccess(SendAccountRecoveryEmailResult Result) {
        OpenLoginPage();
        MessageText.text = "Recovery Email Sent";
    }

    private void OnError(PlayFabError Error) {
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }

    private void OnregisterSuccess(RegisterPlayFabUserResult Result) {
        MessageText.text = "New Account Is Created";
        OpenLoginPage();
    }
    
    public void OpenLoginPage() {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoverPage.SetActive(false);
        TopText.text="LOGIN";
    }

    public void OpenRegisterPage() {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoverPage.SetActive(false);
        TopText.text="Register";
    }

    public void OpenRecoveryPage() {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoverPage.SetActive(true);
        TopText.text="Recovery";
    }
    #endregion



}
