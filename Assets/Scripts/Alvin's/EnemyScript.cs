using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyScript : InteractionTrigger
{
    LogicScript ls;
    public bool beingAttacked = false;
    //public Component playerMovement;
    [SerializeField] private Animator animator;
    public GameObject QTE;

    public override void InteractTrigger()
    {
        QTE.SetActive(true);
        ls = FindObjectOfType<LogicScript>();
        beingAttacked = true;
        //playerMovement.enabled = false;
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
