using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private Button _settingsButton;

    [SerializeField]
    private Button _changeColorButton;
    [SerializeField]
    private Button _customizationButton;
    void Awake()
    {
        _settingsButton.onClick.AddListener(SettingsButtonClick);
        _changeColorButton.onClick.AddListener(ChangeColorButtonClick);
        _customizationButton.onClick.AddListener(CustomizationButtonClick);

    }
    private void ChangeColorButtonClick()
    {
        ColorChanger.Instance.ChangeColor();
    }
    private void SettingsButtonClick()
    {
        //UIManager.Instance.HidePausePanel();
        UIManager.Instance.ShowSettingsPanel();
    }
    private void CustomizationButtonClick()
    {
        //UIManager.Instance.HidePausePanel();
        UIManager.Instance.ShowCustomizationPanel();
    }
}
