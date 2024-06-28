using Assets.EventsController.Constants;
using TMPro;
using UnityEngine;

namespace Assets.EventsController.Example
{
    public class BossDamageIndicator : MonoBehaviour
    {
        TextMeshProUGUI displayText;
        float totalDamage = 0;

        // Start is called before the first frame update
        void Start()
        {
            displayText = GetComponent<TextMeshProUGUI>();
            EventsController.AddTriggerEvent<float>(EventNames.BOSS_HAS_BEEN_DAMAGED, DisplayDamageText);
        }

        private void DisplayDamageText(float damage)
        {
            totalDamage += damage;

            if (totalDamage < 1)
            {
                BossGotHurt(damage);
            }
            else
            {
                BossDied();
            }
        }

        private void BossGotHurt(float damage)
        {
            var text = $"Ouch! that was {totalDamage} Damage!";
            displayText.text = text;
        }

        private void BossDied()
        {
            var text = $"AAAGGGGG!";
            displayText.text = text;
        }
    }
}