using UnityEngine;

public class QTEactivator : InteractionTrigger
{
    public GameObject QTE;
    public override void InteractTrigger()
    {
        QTE.SetActive(true);
    }
}
