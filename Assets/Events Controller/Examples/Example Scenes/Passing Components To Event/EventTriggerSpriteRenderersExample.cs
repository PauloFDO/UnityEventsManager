using Assets.EventsController.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.EventsController.Example
{
    public class EventTriggerSpriteRenderersExample : MonoBehaviour
    {
        IEnumerable<SpriteRenderer> spriteRenderers;

        private void Start()
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            StartCoroutine(CallEventEverySecond());
        }

        IEnumerator CallEventEverySecond()
        {
            yield return new WaitForSeconds(1);
            EventsController.TriggerEvent(EventNames.EVENT_NAME_EXAMPLE, spriteRenderers);
            StartCoroutine(CallEventEverySecond());
        }
    }
}