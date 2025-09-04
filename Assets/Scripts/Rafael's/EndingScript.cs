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
    [SerializeField] GameObject Mating;

    [SerializeField] EndingImagesSO so;

    private IEnumerator Start()
    {
        // Tunggu 0.5 detik di awal
        yield return new WaitForSeconds(0.5f);

        // Logic lain setelah semua komponen kemungkinan sudah load
        death = so.ending.Trim();
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
        else if (death == "Mating")
        {
            Mating.SetActive(true);
        }
        
        


        

    }

  

    

    
}

