using Assets.EventsController.Constants;
using UnityEngine;

namespace Assets.EventsController.Example
{
    public class EventListenerChangeColorExample : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            EventsController.AddTriggerEvent(EventNames.EVENT_NAME_EXAMPLE, CallThisWhenEventTriggered);
        }

        private void CallThisWhenEventTriggered()
        {
            var isColorRed = spriteRenderer.color == Color.red;
            spriteRenderer.color = isColorRed ? Color.blue : Color.red;
        }
    }
}