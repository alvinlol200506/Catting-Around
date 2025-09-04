using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoldInteractable : MonoBehaviour
{
    public LogicScript logicScript;
    public float holdDuration = 3f;  
    private float holdProgress = 0f;  

    public Slider progressBar; 
    private bool isPlayerInRange = false; 
    public TextMeshProUGUI InteractPrompt;
    private bool isComplete=false;
    public ChangeSprite changeSprite;
    public bool TwoWayInteract = true;
    public string name;
    public InteractionTrigger trigger;


    void Start()
    {
        trigger = GetComponent<InteractionTrigger>();
        changeSprite = GetComponent<ChangeSprite>();
        logicScript = FindFirstObjectByType<LogicScript>();

        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false); 
            progressBar.maxValue = holdDuration; 
            progressBar.value = holdProgress; 
        }


        if (string.IsNullOrEmpty(name))
        {
            name = gameObject.name;
         } ;
    }

    void Update()
    {
        if (isPlayerInRange && !isComplete ) 
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                holdProgress += Time.deltaTime; 
                if (progressBar != null)
                    progressBar.value = holdProgress; 

                if (holdProgress >= holdDuration)
                {
                    if (!TwoWayInteract)
                    {
                        isComplete = true;
                    }
                    Interact();
                    
                }
            }
        }


        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isComplete)
        {
            isPlayerInRange = true;
            if (progressBar != null)
                progressBar.gameObject.SetActive(true);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (progressBar != null)
                progressBar.gameObject.SetActive(false); 
            
        }
    }

    void Interact()
    {
        if (progressBar != null)
            progressBar.value=0;


        holdProgress = 0f;
        if (changeSprite != null)
        {
            changeSprite.toggleSprite();
        }

        logicScript.RegisterInteraction(name);

        if (trigger != null)
        {
            trigger.InteractTrigger();
        }


    }
}
