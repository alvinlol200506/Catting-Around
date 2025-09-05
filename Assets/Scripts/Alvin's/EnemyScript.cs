using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyScript : InteractionTrigger
{
    LogicScript ls;
    private bool beingAttacked = false;
    [SerializeField] private Animator animator;
    public override void InteractTrigger()
    {
        ls = FindObjectOfType<LogicScript>();
        beingAttacked = true;
        StartCoroutine(Attacked());
    }

    private IEnumerator Attacked()
    {
        while (beingAttacked)
        {
            ls.HealthEdit(-1, name);
            animator.SetTrigger("Attacked");

            yield return new WaitForSeconds(1f);
        }
    }
}
