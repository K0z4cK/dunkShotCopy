using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonComponent<GameManager>
{
    public int SCORE { get; private set; }
    public int STARS { get; private set; }
    public int HIGHSCORE { get; private set; }
    public int COMBO_MULTIPLIER { get; private set; }
    [SerializeField]
    private Transform _currentBasket;
    [SerializeField]
    private Transform _nextBasket;
    [SerializeField]
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        HIGHSCORE = 0;
        STARS = 0;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HIGHSCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", HIGHSCORE);
        UIManager.Instance.HighScoreUpdated(HIGHSCORE.ToString());

        if (PlayerPrefs.HasKey("Stars"))
        {
            STARS = PlayerPrefs.GetInt("Stars");
        }
        PlayerPrefs.SetInt("Stars", STARS);
        UIManager.Instance.StarsUpdated(STARS.ToString());

        SCORE = 0;
        UIManager.Instance.ScoreUpdated(SCORE.ToString());

        COMBO_MULTIPLIER = 1;
        EventManager.Instance.basketCreate.AddListener(UpdateBaskets);
        EventManager.Instance.ballCatch.AddListener(CountScore);
        EventManager.Instance.starCatch.AddListener(AddStar);
        EventManager.Instance.restartGame.AddListener(RestartGame);
        EventManager.Instance.soundChange.AddListener(ChangeSound);
        //EventManager.Instance.ballCatchBack.AddListener(UpdateBasketsBack);

    }
    private void RestartGame()
    {
        StartCoroutine(RestartCoroutine());
    }
    private IEnumerator RestartCoroutine()
    {
       

        yield return new WaitForSeconds(GetComponentInChildren<AudioSource>().time+0.039f);
            Application.LoadLevel("Main");

    }
    private void ChangeSound()
    {
        bool isOn = PlayerPrefs.GetInt("SoundOn") == 1;
        AudioListener.volume = isOn ? 1: 0;
    }
    private void UpdateBaskets(GameObject newBasket)
    {
        Destroy(_currentBasket.gameObject);     
        _currentBasket = _nextBasket;
        _nextBasket = newBasket.transform;
        EventManager.Instance.OnBasketUpdate(_currentBasket);
    }
    /*private void UpdateBasketsBack(GameObject basket)
    {
        _nextBasket = _currentBasket;
        _currentBasket = basket.transform;
        EventManager.Instance.OnBasketUpdate(_currentBasket);

    }*/
    private void AddStar()
    {
        STARS++;
        PlayerPrefs.SetInt("Stars", STARS);
        UIManager.Instance.StarsUpdated(STARS.ToString());

    }
    private void CountScore()
    {
        print("wall bounces: " + Ball.Instance.WALL_BOUNCE_COUNT);
        int bounceCount = Ball.Instance.BOUNCE_COUNT;
        int wallBounceMultiplier = Ball.Instance.WALL_BOUNCE_COUNT == 0 ? 1:2;
        if (bounceCount == 0)
        {
            COMBO_MULTIPLIER++;
            audioSource.Play();
        }
        else
            COMBO_MULTIPLIER = 1;
        print("COMBO_MULTIPLIER: " + COMBO_MULTIPLIER + "; "+ "wallBounceMultiplier: " + wallBounceMultiplier);
        SCORE += 1 * COMBO_MULTIPLIER * wallBounceMultiplier;

        if (SCORE > HIGHSCORE)
            HIGHSCORE = SCORE;
        PlayerPrefs.SetInt("HighScore", HIGHSCORE);

        print("score: " + SCORE);
        UIManager.Instance.ScoreUpdated(SCORE.ToString());

    }
}
