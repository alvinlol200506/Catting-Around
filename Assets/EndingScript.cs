using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndingScript : MonoBehaviour
{

    [SerializeField] public List<Sprite> images = new List<Sprite>();
     [SerializeField] GameObject EndingPanel;
    UnityEngine.UI.Image imagenya;
    void Start()
    {

        imagenya = EndingPanel.GetComponent<UnityEngine.UI.Image>();
        String death = DeathData.causeOfDeath;

        switch (death)
        {
            case "High":
                imagenya.sprite = images[2];
                break;

            default:
                imagenya.sprite = images[0];
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    
}

