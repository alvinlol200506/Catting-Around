using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        float durasi = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, durasi);
    }
}