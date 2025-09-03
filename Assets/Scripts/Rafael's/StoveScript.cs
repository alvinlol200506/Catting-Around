using UnityEngine;

public class StoveScript : InteractionTrigger
{
    public float knockbackForce = 5f;
    public bool on = false;

    LogicScript ls;

    public override void InteractTrigger()
    {
        ls = FindObjectOfType<LogicScript>();
        on = true;
        Debug.Log("turn on");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (on)
        {
            ls.HealthEdit(-2);
        }   
    }
}

