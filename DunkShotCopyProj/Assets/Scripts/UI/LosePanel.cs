using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LosePanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _highScoreText;
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private Button _restartButton;

    [SerializeField] 
    private Button _settingsButton;

    [SerializeField]
    private Button _likeButton;
    void Awake()
    {

        _restartButton.onClick.AddListener(RestartButtonClick);
        _settingsButton.onClick.AddListener(SettingsButtonClick);
        _likeButton.onClick.AddListener(LikeButtonClick);
    }

    private void OnEnable()
    {
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        _scoreText.text = GameManager.Instance.SCORE.ToString();
    }


    private void RestartButtonClick()
    {
        UIManager.Instance.HideLosePanel();
        UIManager.Instance.ShowMenuPanel();
        EventManager.Instance.GameRestarted();
    }
    private void SettingsButtonClick()
    {
        //UIManager.Instance.HidePausePanel();
        UIManager.Instance.ShowSettingsPanel();
    }
    private void LikeButtonClick()
    {
        Application.OpenURL("https://github.com/K0z4cK/dunkShotCopy");
    }



}
