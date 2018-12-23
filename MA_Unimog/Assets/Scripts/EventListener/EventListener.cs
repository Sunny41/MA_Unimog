using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventListener: MonoBehaviour
{

    private Dictionary<string, UnityEvent> eventDictionary;
    private Dictionary<string, UnityEvent<int>> eventDictionaryInt;
    private Dictionary<string, UnityEvent<float>> eventDictionaryFloat;
    private Dictionary<string, UnityEvent<string>> eventDictionaryString;

    private static EventListener eventManager;

    public static EventListener instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventListener)) as EventListener;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
        if(eventDictionaryInt == null)
        {
            eventDictionaryInt = new Dictionary<string, UnityEvent<int>>();
        }
        if(eventDictionaryFloat == null)
        {
            eventDictionaryFloat = new Dictionary<string, UnityEvent<float>>();
        }
        if(eventDictionaryString == null)
        {
            eventDictionaryString = new Dictionary<string, UnityEvent<string>>();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }


    public static void StartListening(string eventName, UnityAction<int> listener)
    {
        UnityEvent<int> thisEvent = null;
        if (instance.eventDictionaryInt.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new ThisEventInt();
            thisEvent.AddListener(listener);
            instance.eventDictionaryInt.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<int> listener)
    {
        if (eventManager == null) return;
        UnityEvent<int> thisEvent = null;
        if (instance.eventDictionaryInt.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, int value)
    {
        UnityEvent<int> thisEvent = null;
        if (instance.eventDictionaryInt.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(value);
        }
    }


    public static void StartListening(string eventName, UnityAction<float> listener)
    {
        UnityEvent<float> thisEvent = null;
        if (instance.eventDictionaryFloat.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new ThisEventFloat();
            thisEvent.AddListener(listener);
            instance.eventDictionaryFloat.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<float> listener)
    {
        if (eventManager == null) return;
        UnityEvent<float> thisEvent = null;
        if (instance.eventDictionaryFloat.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, float value)
    {
        UnityEvent<float> thisEvent = null;
        if (instance.eventDictionaryFloat.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(value);
        }
    }


    public static void StartListening(string eventName, UnityAction<string> listener)
    {
        UnityEvent<string> thisEvent = null;
        if (instance.eventDictionaryString.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new ThisEventString();
            thisEvent.AddListener(listener);
            instance.eventDictionaryString.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<string> listener)
    {
        if (eventManager == null) return;
        UnityEvent<string> thisEvent = null;
        if (instance.eventDictionaryString.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, string value)
    {
        UnityEvent<string> thisEvent = null;
        if (instance.eventDictionaryString.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(value);
        }
    }
}

public class ThisEventInt : UnityEvent<int>
{

}

public class ThisEventFloat : UnityEvent<float>
{

}

public class ThisEventString : UnityEvent<string>
{

}