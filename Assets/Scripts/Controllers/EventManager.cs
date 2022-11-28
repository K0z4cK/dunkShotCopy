using UnityEngine;
using UnityEngine.Events;

public class EventManager : SingletonComponent<EventManager>
{
    internal UnityEvent gameStart = new UnityEvent();
    internal UnityEvent gameOver = new UnityEvent();
    internal UnityEvent restartGame = new UnityEvent();


    internal UnityEvent ballCatch = new UnityEvent();
    internal UnityEvent starCatch = new UnityEvent();

    //internal UnityEvent<GameObject> ballCatchBack = new UnityEvent<GameObject>();
    internal UnityEvent ballShot = new UnityEvent();
    internal UnityEvent<GameObject> basketCreate = new UnityEvent<GameObject>();
    internal UnityEvent<Transform> basketUpdate = new UnityEvent<Transform>();

    internal UnityEvent colorChange = new UnityEvent();
    internal UnityEvent vibroChange = new UnityEvent();
    internal UnityEvent soundChange = new UnityEvent();


    internal void GameStarted() => gameStart?.Invoke();
    internal void GameOvered() => gameOver?.Invoke();
    internal void GameRestarted() => restartGame?.Invoke();

    internal void BallCatched() => ballCatch?.Invoke();
    internal void StarCatched() => starCatch?.Invoke();

    //internal void BallCatchedBack(GameObject basket) => ballCatchBack?.Invoke(basket);
    internal void BallShoted() => ballShot?.Invoke();

    internal void ColorChanged() => colorChange?.Invoke();
    internal void VibroChanged() => vibroChange?.Invoke();
    internal void SoundChanged() => soundChange?.Invoke();



    internal void OnBasketCreate(GameObject basket) => basketCreate?.Invoke(basket);
    internal void OnBasketUpdate(Transform basket) => basketUpdate?.Invoke(basket);

}
