using System;
using System.Collections.Generic;

public static class CustomEventManager
{
    //Example Events, feel free to use them or make your own in separate classes
    public delegate void OnTapEvent();
    public delegate void OnDoubleTapEvent();
    public delegate void OnPressEvent();
    public delegate void OnHoldEvent();
    public delegate void OnReleaseEvent();
    public delegate void OnPinchEvent();
    public delegate void OnDebugEvent();

    private static Dictionary<Type, Delegate> _EventDictionary = new Dictionary<Type, Delegate>();

    public static void Subscribe<T>(Action pMethodToSubscribe) where T : Delegate
    {
        Type lEventType = typeof(T);

        if(_EventDictionary.TryGetValue(lEventType, out Delegate pExistingDelegate))
        {
            _EventDictionary[lEventType] = Delegate.Combine(pExistingDelegate, pMethodToSubscribe);
            return;
        }

        _EventDictionary[lEventType] = pMethodToSubscribe;
    }

    public static void Unsubscribe<T>(Action pMethodToUnsubscribe) where T : Delegate
    {
        Type lEventType = typeof(T);

        if (!_EventDictionary.TryGetValue(lEventType, out Delegate pExistingDelegate))
        {
            return;
        }

        Delegate lUpdatedDelegate = Delegate.Remove(pExistingDelegate, pMethodToUnsubscribe);

        if (lUpdatedDelegate != null)
        {
            _EventDictionary[lEventType] = lUpdatedDelegate;
            return;
        }

        _EventDictionary.Remove(lEventType);
    }

    public static void InvokeEvent<T>() where T : Delegate
    {
        Type lEventType = typeof(T);

        if(_EventDictionary.TryGetValue(lEventType,out Delegate pExistingDelegate))
        {
            (pExistingDelegate as Action).Invoke();
        }
    }
}
