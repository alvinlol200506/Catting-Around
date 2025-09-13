using UnityEngine;

public class PointerController : MonoBehaviour
{
    public Transform pointA; // Reference to the starting point
    public Transform pointB; // Reference to the ending point
    public RectTransform safeZone; // Reference to the safe zone RectTransform
    public float moveSpeed = 100f; // Speed of the pointer movement
    [SerializeField] GameObject QTE;
    LogicScript ls;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private GameObject  SlashEffect;
    [SerializeField] private GameObject  enemy;





    private float direction = 1f; // 1 for moving towards B, -1 for moving towards A
    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
        ls = FindObjectOfType<LogicScript>();
    }

    void Update()
    {
        // Move the pointer towards the target position
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Change direction if the pointer reaches one of the points
        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            direction = -1f;
        }

        // Check for input
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckSuccess();
        }
    }

    void CheckSuccess()
    {
        // Check if the pointer is within the safe zone
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            ls.EnemyHealthEdit(-1);
           // Debug.Log("Success!");
            animator.SetTrigger("Hit");
            animatorPlayer.SetTrigger("Attacks");
            Instantiate(SlashEffect,enemy.transform.position,enemy.transform.rotation);
        }
        else
        {
            //Debug.Log("Fail!");
        }
    }
}
