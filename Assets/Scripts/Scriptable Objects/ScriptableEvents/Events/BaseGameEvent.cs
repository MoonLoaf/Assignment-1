using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEvent<T> : ScriptableObject
{
    private readonly List<IGameEventListener<T>> _eventlisteners = new List<IGameEventListener<T>>();

    public void Raise(T item)
    {
        for (int i = _eventlisteners.Count - 1; i >= 0; i--)
        {
            _eventlisteners[i].OnEventRaised(item);
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        if (!_eventlisteners.Contains(listener))
        {
            _eventlisteners.Add(listener);
        }
    }

    public void UnregisterListener(IGameEventListener<T> listener)
    {
        if (_eventlisteners.Contains(listener))
        {
            _eventlisteners.Remove(listener);
        }
    }
}