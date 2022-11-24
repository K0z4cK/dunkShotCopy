using UnityEngine;
using UnityEngine.Events;

public class EventManager : SingletonComponent<EventManager>
    {
        internal UnityEvent ballCatch = new UnityEvent();
        //internal UnityEvent<GameObject> ballCatchBack = new UnityEvent<GameObject>();
        internal UnityEvent ballShot = new UnityEvent();
        internal UnityEvent<GameObject> basketCreate = new UnityEvent<GameObject>();
        internal UnityEvent<Transform> basketUpdate = new UnityEvent<Transform>();

        internal void BallCatched() => ballCatch?.Invoke();
        //internal void BallCatchedBack(GameObject basket) => ballCatchBack?.Invoke(basket);
        internal void BallShoted() => ballShot?.Invoke();

        internal void OnBasketCreate(GameObject basket) => basketCreate?.Invoke(basket);
        internal void OnBasketUpdate(Transform basket) => basketUpdate?.Invoke(basket);

}
