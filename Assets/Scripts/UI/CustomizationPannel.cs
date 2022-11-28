using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationPannel : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;
    void Awake()
    {
        _backButton.onClick.AddListener(BackButtonClicked);
    }
    private void BackButtonClicked()
    {
        UIManager.Instance.HideCustomizationPanel();
    }
}
