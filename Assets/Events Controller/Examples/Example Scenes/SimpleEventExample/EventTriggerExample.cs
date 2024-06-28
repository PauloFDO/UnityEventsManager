using Assets.EventsController.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.EventsController.Example
{
    public class EventTriggerExample : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(CallEventEverySecond());
        }

        IEnumerator CallEventEverySecond()
        {
            yield return new WaitForSeconds(1);
            EventsController.TriggerEvent(EventNames.EVENT_NAME_EXAMPLE);
            StartCoroutine(CallEventEverySecond());
        }
    }
}