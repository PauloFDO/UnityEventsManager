using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.EventsController
{
    public class EventsController : MonoBehaviour
    {
        private static Dictionary<string, object> eventDictionary;

        private void Awake()
        {
            ResetEventDictionary();
        }

        public static void AddTriggerEvent<T>(string eventName, UnityAction<T> methodToTriggerOnEvent)
        {
            if (eventDictionary == null) { ResetEventDictionary(); }

            var unityEvent = new UnityEvent<T>();
            unityEvent.AddListener(methodToTriggerOnEvent);

            AddNewEvent(eventName, unityEvent);
        }

        public static void AddTriggerEvent(string eventName, UnityAction methodToTriggerOnEvent)
        {
            if (eventDictionary == null) { ResetEventDictionary(); }

            var unityEvent = new UnityEvent();
            unityEvent.AddListener(methodToTriggerOnEvent);
            AddNewEvent(eventName, unityEvent);
        }

        private static void AddNewEvent<T>(string eventName, T newEvent)
        {
            if (!eventDictionary.ContainsKey(eventName))
            {
                var unityEventsList = new List<T>();
                unityEventsList.Add(newEvent);
                eventDictionary.Add(eventName, unityEventsList);
            }
            else
            {
                var existingEvent = (List<T>)eventDictionary[eventName];
                existingEvent.Add(newEvent);
            }
        }

        public static void DeleteEvent(string eventName)
        {
            if (!EventExists(eventName))
            {
                Debug.LogWarning("You are trying to delete an event that does not exist");
                return;
            }

            if (eventDictionary.ContainsKey(eventName))
            {
                eventDictionary.Remove(eventName);
            }
        }

        public static void TriggerEvent<T>(string eventName, T args)
        {
            if (!EventExists(eventName))
            {
                Debug.LogWarning("You are trying to trigger an event that does not exist, be sure to add an event with 'AddTriggerEvent' before executing it");
                return;
            }

            var eventsToTrigger = (List<UnityEvent<T>>)eventDictionary[eventName];

            foreach (var myEvent in eventsToTrigger)
            {
                myEvent.Invoke(args);
            }
        }

        public static void TriggerEvent(string eventName)
        {
            if (!EventExists(eventName))
            {
                Debug.LogWarning("You are trying to trigger an event that does not exist, be sure to add an event with 'AddTriggerEvent' before executing it");
                return;
            }

            var eventsToTrigger = (List<UnityEvent>)eventDictionary[eventName];

            foreach (var myEvent in eventsToTrigger)
            {
                myEvent.Invoke();
            }
        }

        public static bool EventExists(string eventName)
        {
            return eventDictionary != null && eventDictionary.ContainsKey(eventName);
        }

        public static void ResetEventDictionary()
        {
            eventDictionary = new Dictionary<string, object>();
        }

        private static void OnDestroy()
        {
            eventDictionary = null;
        }
    }
}