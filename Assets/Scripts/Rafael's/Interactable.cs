using System;
using UnityEngine;
using UnityEngine.UI;

public class HoldInteractable : MonoBehaviour
{
    //public MainLOGIC tracker;
    public float holdDuration = 3f;  
    private float holdProgress = 0f;  

    //public Slider progressBar; 
    private bool isPlayerInRange = false; 
    public Text InteractPrompt;
    private bool isComplete=false;
    public ChangeSprite changeSprite;
    public bool TwoWayInteract = true;
   


    void Start()
    {
        changeSprite = GetComponent<ChangeSprite>();
        //tracker = FindFirstObjectByType<MainLOGIC>();
       // if (tracker == null)
        // {
        //     Debug.LogError("MainLOGIC script not found in the scene!");
        // }

        // if (progressBar != null)
        // {
        //     progressBar.gameObject.SetActive(false); 
        //     progressBar.maxValue = holdDuration; 
        //     progressBar.value = holdProgress; 
        // }
    }

    void Update()
    {
        if (isPlayerInRange && !isComplete 
        //&& tracker.islightsOn 
        ) 
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                holdProgress += Time.deltaTime; 
                // if (progressBar != null)
                //     progressBar.value = holdProgress; 

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

        // if (progressBar != null)
        // {
        //     Camera mainCam = Camera.main;
        //     if (mainCam != null)
        //         progressBar.transform.LookAt(mainCam.transform);
        // }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player") && !isComplete)
        {
            isPlayerInRange = true;
            // if (progressBar != null)
            //     progressBar.gameObject.SetActive(true); 
           
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
       // if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // if (progressBar != null)
            //     progressBar.gameObject.SetActive(false); 
        }
    }

    void Interact()
    {
        //changeMaterial.cleaned();
        // if (progressBar != null)
        //     progressBar.gameObject.SetActive(false);


        holdProgress = 0f;
        //tracker.CompleteObjective();
        changeSprite.toggleSprite();

        Debug.Log("Interaction Complete!");

    }
}
