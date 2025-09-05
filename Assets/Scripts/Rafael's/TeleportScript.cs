using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TeleportScript : InteractionTrigger
{
    
    public GameObject to;
    public SoundtrackScript sts;

    public override void InteractTrigger()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = to.transform.position;
        if (sts != null)
        {
            sts.togglesound();
        }
    }
}
