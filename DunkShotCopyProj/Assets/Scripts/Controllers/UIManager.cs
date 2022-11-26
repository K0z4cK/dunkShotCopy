using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : SingletonComponent<UIManager>
{
    [SerializeField]
    private GameObject _gamePanel;
    [SerializeField]
    private GameObject _menuPanel;
    [SerializeField]
    private GameObject _settingsPanel;
    [SerializeField]
    private GameObject _losePanel;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _customizationPanel;

    private void Awake()
    {
        ShowMenuPanel();
        EventManager.Instance.gameStart.AddListener(ShowGamePanel);
        EventManager.Instance.gameOver.AddListener(ShowLosePanel);
    }

    public void HideMenuPanel()
    {
        _menuPanel.SetActive(false);
    }
    public void ShowMenuPanel()
    {
        HideGamePanel();
        HideSettingsPanel();
        HideLosePanel();
        HidePausePanel();
        HideCustomizationPanel();
        _menuPanel.SetActive(true);
    }

    public void HideGamePanel()
    {
        _gamePanel.SetActive(false);
    }
    public void ShowGamePanel()
    {
        HideMenuPanel();
        HideSettingsPanel();
        HideLosePanel();
        HidePausePanel();
        HideCustomizationPanel();
        _gamePanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }
    public void ShowSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void HideLosePanel()
    {
        _losePanel.SetActive(false);
    }
    public void ShowLosePanel()
    {
        HideMenuPanel();
        HideGamePanel();
        HideSettingsPanel();
        HidePausePanel();
        HideCustomizationPanel();
        _losePanel.SetActive(true);
    }
    public void HidePausePanel()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }
    public void ShowPausePanel()
    {
        Time.timeScale = 0;
        HideMenuPanel();
        HideGamePanel();
        HideSettingsPanel();
        HideLosePanel();
        HideCustomizationPanel();
        _pausePanel.SetActive(true);
    }

    public void HideCustomizationPanel()
    {
        _customizationPanel.SetActive(false);
    }
    public void ShowCustomizationPanel()
    {
        _customizationPanel.SetActive(true);
    }

    internal UnityEvent<string> scoreUpdate = new UnityEvent<string>();
    internal UnityEvent<string> highScoreUpdate = new UnityEvent<string>();
    internal UnityEvent<string> starsUpdate = new UnityEvent<string>();

    internal void ScoreUpdated(string score) => scoreUpdate?.Invoke(score);
    internal void HighScoreUpdated(string highScore) => highScoreUpdate?.Invoke(highScore);
    internal void StarsUpdated(string stars) => starsUpdate?.Invoke(stars);


}
