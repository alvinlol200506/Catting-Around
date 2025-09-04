using JetBrains.Annotations;
using UnityEngine;

public class TeleportScript : InteractionTrigger
{
   
    public GameObject to;

    public override void InteractTrigger()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = to.transform.position;
    }
}
