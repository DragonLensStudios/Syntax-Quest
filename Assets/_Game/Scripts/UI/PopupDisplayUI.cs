using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using static UnityEngine.UI.Button;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PopupDisplayUI : MonoBehaviour
{
    public static PopupDisplayUI instance;

    [SerializeField] private GameObject confirmDialog, optionsDialog;
    
    [SerializeField] private TMP_Text confimPopupText, optionsPopupText;

    [SerializeField] private Button confirmButton, cancelButton, option1Button, option2Button, option3Button, option4Button;
    public GameObject ConfirmDialog { get => confirmDialog; set => confirmDialog = value; }
    public GameObject OptionsDialog { get => optionsDialog; set => optionsDialog = value; }
    public TMP_Text PopupText { get => confimPopupText; set => confimPopupText = value; }
    public TMP_Text OptionsPopupText { get => optionsPopupText; set => optionsPopupText = value; }
    public Button ConfirmButton { get => confirmButton; set => confirmButton = value; }
    public Button CancelButton { get => cancelButton; set => cancelButton = value; }
    public Button Option1Button { get => option1Button; set => option1Button = value; }
    public Button Option2Button { get => option2Button; set => option2Button = value; }
    public Button Option3Button { get => option3Button; set => option3Button = value; }
    public Button Option4Button { get => option4Button; set => option4Button = value; }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void ShowOptionsPopup(string text, UnityAction option1Action = null,
        UnityAction option2Action = null, UnityAction option3Action = null, UnityAction option4Action = null)
    {
        optionsDialog.gameObject.SetActive(true);
        optionsPopupText.text = text;
        if(option1Action != null)
        {
            option1Button.onClick.AddListener(option1Action);
            option1Button.onClick.AddListener(HideOptionsDialog);
            option1Button.gameObject.SetActive(true);
        }
        else
        {
            option1Button.gameObject.SetActive(false);
        }
        if(option2Action != null)
        {
            option2Button.onClick.AddListener(option2Action);
            option2Button.onClick.AddListener(HideOptionsDialog);
            option2Button.gameObject.SetActive(true);
        }
        else
        {
            option2Button.gameObject.SetActive(false);
        }
        if(option3Action != null)
        {
            option3Button.onClick.AddListener(option3Action);
            option3Button.onClick.AddListener(HideOptionsDialog);
            option3Button.gameObject.SetActive(true);
        }
        else
        {
            option3Button.gameObject.SetActive(false);
        }
        if(option4Action != null)
        {
            option4Button.onClick.AddListener(option4Action);
            option4Button.onClick.AddListener(HideOptionsDialog);
            option4Button.gameObject.SetActive(true);
        }
        else
        {
            option4Button.gameObject.SetActive(false);
        }
    }
    
    public void ShowConfirmPopup(string text, UnityAction confirmAction = null, UnityAction cancelAction = null)
    {
        confirmDialog.gameObject.SetActive(true);
        confimPopupText.text = text;
        if(confirmAction != null)
        {
            confirmButton.onClick.AddListener(confirmAction);
            confirmButton.onClick.AddListener(HideConfrimDialog);
            confirmButton.gameObject.SetActive(true);
        }
        else
        {
            confirmButton.gameObject.SetActive(false);
        }
        if (cancelAction != null)
        {
            cancelButton.onClick.AddListener(cancelAction);
            cancelButton.onClick.AddListener(HideConfrimDialog);
            cancelButton.gameObject.SetActive(true);
        }
        else
        {
            cancelButton.gameObject.SetActive(false);
        }
    }

    public void HideAllPopups()
    {
        confirmDialog.SetActive(false);
        optionsDialog.SetActive(false);
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();
        option3Button.onClick.RemoveAllListeners();
        option4Button.onClick.RemoveAllListeners();
    }
    
    public void HideConfrimDialog()
    {
        confirmDialog.SetActive(false);
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
    }
    
    public void HideOptionsDialog()
    {
        optionsDialog.SetActive(false);
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();
        option3Button.onClick.RemoveAllListeners();
        option4Button.onClick.RemoveAllListeners();
    }
}
