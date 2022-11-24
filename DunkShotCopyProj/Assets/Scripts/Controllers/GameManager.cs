using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _score;
    private int _comboMultiplier;
    [SerializeField]
    private Transform _currentBasket;
    [SerializeField]
    private Transform _nextBasket;

    private void Awake()
    {
        _score = 0;
        _comboMultiplier = 1;
        EventManager.Instance.basketCreate.AddListener(UpdateBaskets);
        EventManager.Instance.ballCatch.AddListener(CountScore);
        //EventManager.Instance.ballCatchBack.AddListener(UpdateBasketsBack);

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
    private void CountScore()
    {
        print("wall bounces: " + Ball.Instance.WALL_BOUNCE_COUNT);
        int bounceCount = Ball.Instance.BOUNCE_COUNT;
        int wallBounceMultiplier = Ball.Instance.WALL_BOUNCE_COUNT == 0 ? 1:2;
        if (bounceCount == 0)
            _comboMultiplier++;
        else
            _comboMultiplier = 1;
        print("_comboMultiplier: " + _comboMultiplier + "; "+ "wallBounceMultiplier: " + wallBounceMultiplier);
        _score += 1 * _comboMultiplier * wallBounceMultiplier;
        print("score: " + _score);
    }
}
