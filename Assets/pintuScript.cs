using UnityEngine;

public class pintuScript : InteractionTrigger
{
    [SerializeField] GameObject IsiToilet;
    public override void InteractTrigger()
    {
        IsiToilet.SetActive(true);
    }
}
