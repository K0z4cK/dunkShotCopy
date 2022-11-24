using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class EventManager : SingletonComponent<EventManager>
    {
        internal UnityEvent itemCreate = new UnityEvent();
        internal UnityEvent<int> timerTick = new UnityEvent<int>();
        internal void ItemCreated() => itemCreate?.Invoke();
        internal void OnTimerTick(int value) => timerTick?.Invoke(value);
    }
}