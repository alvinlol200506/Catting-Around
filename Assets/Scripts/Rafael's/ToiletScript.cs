using UnityEngine;

public class ToiletScript : InteractionTrigger
{
    LogicScript ls;

    void Start()
    {
        ls = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public override void InteractTrigger()
    {
        ls.HealthEdit(-2, name);
     }
}
