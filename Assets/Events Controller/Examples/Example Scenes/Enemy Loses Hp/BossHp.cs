using Assets.EventsController.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.EventsController.Example
{
    public class BossHp : MonoBehaviour
    {
        Slider bossHpSlider;

        // Start is called before the first frame update
        void Start()
        {
            bossHpSlider = GetComponent<Slider>();
            EventsController.AddTriggerEvent<float>(EventNames.BOSS_HAS_BEEN_DAMAGED, BossGotHurt);
        }

        private void BossGotHurt(float damage)
        {
            bossHpSlider.value -= damage;
        }
    }
}