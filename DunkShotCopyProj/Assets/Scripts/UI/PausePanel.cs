using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button _mainMenuButton;

    [SerializeField] //TODO
    private Button _customizeButton;

    [SerializeField]
    private Button _continueButton;

    [SerializeField]
    private Button _settingsButton;

    private void Awake()
    {
        _mainMenuButton.onClick.AddListener(MainMenuButtonClick);
        _customizeButton.onClick.AddListener(CustomizeButtonClick);
        _continueButton.onClick.AddListener(ContinueButtonClick);
        _settingsButton.onClick.AddListener(SettingsButtonClick);
    }
    private void MainMenuButtonClick()
    {
        UIManager.Instance.HidePausePanel();
        UIManager.Instance.ShowMenuPanel();
        EventManager.Instance.GameRestarted();
    }
    private void ContinueButtonClick()
    {
        UIManager.Instance.HidePausePanel();
        UIManager.Instance.ShowGamePanel();
    }
    private void SettingsButtonClick()
    {
        //UIManager.Instance.HidePausePanel();
        UIManager.Instance.ShowSettingsPanel();
    }
    private void CustomizeButtonClick()
    {
        UIManager.Instance.ShowCustomizationPanel();
    }

}
