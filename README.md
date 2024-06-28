# UnityEventsManager

## With event manager you can add as many listeners as you want with just one line of code

You only need this file, everything else are examples: https://github.com/PauloFDO/UnityEventsManager/blob/main/Assets/Events%20Controller/EventsController.cs

1. Create an event with "AddTriggerEvent", for example:
```
    void Start()
    {
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
```

2. Now This event can be triggered from anywhere in your scene, for example:
```
    private void OnMouseUp()
    {
        BossHasBeenDamaged();
    }

    private void BossHasBeenDamaged()
    {
        var clickDamage = 0.1f;
        EventsController.TriggerEvent(EventNames.BOSS_HAS_BEEN_DAMAGED, clickDamage);
    }
```

3. if you need to send complex objects you can send it in a class
```
    private void Awake()
    {
        EventsController.AddTriggerEvent<HorseRagdollPosition>(EventNames.HORSE_DIED, TriggerHorseRagdoll);
    }

    private void TriggerHorseRagdoll(HorseRagdollPosition position)
    {
        Debug.Log("horse ragdoll triggered on position "+ position.Position);
        Debug.Log("horse ragdoll with rotation "+ position.Rotation);
    }
```

then just call it:

```
 var horsePosition = new HorseRagdollPosition { Position = transform.ValueRO.Position, Rotation = transform.ValueRO.Rotation };
 EventsController.TriggerEvent(EventNames.HORSE_DIED, horsePosition);
```


Tips:

- You can add many listeners so when the boss is damage you could reduce it's HP, show a text message or alert minions about their boss being damaged
  all from 1 event trigger, check the Scene in the Examples folder "EnemyLosesHpExample" for a working example of this.

- You will likely want to add all your event listeners during start or Awake.

TIP: Try to keep the event names organised and centralised so you know how events are connected, by doing this:

EventsController.TriggerEvent(EventNames.My_Event_Name, clickDamage);

instead of

EventsController.TriggerEvent("My event name", clickDamage);
