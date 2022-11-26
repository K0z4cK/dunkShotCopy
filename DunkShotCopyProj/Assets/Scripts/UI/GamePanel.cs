using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private Button _pauseButton;
   
    void Awake()
    {
        UIManager.Instance.scoreUpdate.AddListener(UpdateScore);
        _pauseButton.onClick.AddListener(PauseButtonClick);
    }

    private void PauseButtonClick()
    {
        UIManager.Instance.ShowPausePanel();
    }
    private void UpdateScore(string newScore)
    {
        _scoreText.text = newScore;
    }
   
}
