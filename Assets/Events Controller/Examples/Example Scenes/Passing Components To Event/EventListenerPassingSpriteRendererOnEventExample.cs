using Assets.EventsController.Constants;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.EventsController.Example
{
    public class EventListenerPassingSpriteRendererOnEventExample : MonoBehaviour
    {
        void Awake()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            EventsController.AddTriggerEvent<IEnumerable<SpriteRenderer>>(EventNames.EVENT_NAME_EXAMPLE, CallThisWhenEventTriggered);
        }

        private void CallThisWhenEventTriggered(IEnumerable<SpriteRenderer> spriteRenderers)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                var isColorRed = spriteRenderer.color == Color.red;
                spriteRenderer.color = isColorRed ? Color.blue : Color.red;
            }
        }
    }
}