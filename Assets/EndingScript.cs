using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class EndingScript : MonoBehaviour
{

    [SerializeField] public List<Sprite> images = new List<Sprite>();
     [SerializeField] GameObject EndingPanel;
    [SerializeField] int force;
     [SerializeField] string stringdeath;
    [SerializeField] bool DEVMODE;
    UnityEngine.UI.Image imagenya;
    String death;
    [SerializeField] GameObject Toilet;
    [SerializeField] GameObject Stove;
    [SerializeField] GameObject Catnip;
    [SerializeField] EndingImagesSO so;

    void Start()
    {

        death = so.ending;
        Debug.Log(death);
        if (DEVMODE)
        {
            death = stringdeath;
        }




        if (death == "High")
        {
            Catnip.SetActive(true);
            
            }
        else if (death == "Toilet")
        {
            Toilet.SetActive(true);
        }
        else if (death == "Stove")
        {
            Stove.SetActive(true);
        }
        
        


        

    }

  

    

    
}

