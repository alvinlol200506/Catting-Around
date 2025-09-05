using UnityEditor;
using UnityEngine;

public class pintuScript : InteractionTrigger
{
    [SerializeField] GameObject IsiToilet;
    [SerializeField] SoundEffectScript ses;
    public override void InteractTrigger()
    {
        ses.pintuEffect();
        IsiToilet.SetActive(true);
    }
}
