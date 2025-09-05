using UnityEngine;

public class TeleportScript : InteractionTrigger
{
    
    public GameObject to;
    public SoundtrackScript sts;
    public SoundEffectScript ses;

    public override void InteractTrigger()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = to.transform.position;
        if (sts != null)
        {
            sts.togglesound();
            ses.windowEffect();
        }
    }
}
