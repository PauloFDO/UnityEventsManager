using Assets.EventsController.Constants;
using UnityEngine;

namespace Assets.EventsController.Example
{
    public class TriggerEventOnClick : MonoBehaviour
    {
        private void OnMouseUp()
        {
            BossHasBeenDamaged();
        }

        private void BossHasBeenDamaged()
        {
            var clickDamage = 0.1f;
            EventsController.TriggerEvent(EventNames.BOSS_HAS_BEEN_DAMAGED, clickDamage);
        }
    }
}