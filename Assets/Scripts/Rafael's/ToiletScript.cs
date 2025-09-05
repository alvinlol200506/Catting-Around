using UnityEngine;

public class ToiletScript : InteractionTrigger
{
    LogicScript ls;
    public SoundEffectScript ses;

    void Start()
    {
        ls = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public override void InteractTrigger()
    {
        ses.toiletEffect();
        ls.HealthEdit(-2, name);
     }
}
