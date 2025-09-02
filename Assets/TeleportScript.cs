using JetBrains.Annotations;
using UnityEngine;

public class TeleportScript : InteractionTrigger
{
    public float x,y;

    public override void InteractTrigger()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector2(x, y);
    }
}
