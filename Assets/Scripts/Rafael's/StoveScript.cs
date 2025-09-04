using UnityEngine;

public class StoveScript : InteractionTrigger
{
    public float knockbackForce = 5f;
    public bool on = false;

    LogicScript ls;
    [SerializeField] private Animator animator;

    private bool playerInStove = false;
    private bool canBurn = true;

    public override void InteractTrigger()
    {
        ls = FindObjectOfType<LogicScript>();
        on = true;
        Debug.Log("turn on");
        OnTriggerEnter2D(null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (on)
        {
            playerInStove = true;
            if (canBurn)
                StartCoroutine(BurnLoop(other));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
            playerInStove = false;
        
    }

    private System.Collections.IEnumerator BurnLoop(Collider2D player)
    {
        while (playerInStove && on)
        {
            canBurn = false;
            ls.HealthEdit(-2, name);
            BurnPlayer();
            yield return new WaitForSeconds(1f);
            canBurn = true;
        }
    }

    public void BurnPlayer()
    {
        animator.SetTrigger("Burn");
    }
}

