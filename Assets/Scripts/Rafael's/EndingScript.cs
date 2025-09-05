using System;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EndingScript : MonoBehaviour
{

    [SerializeField] string stringdeath;
    [SerializeField] bool DEVMODE;
    String death;

    [SerializeField] GameObject Toilet;
    [SerializeField] GameObject Stove;
    [SerializeField] GameObject Catnip;
    [SerializeField] GameObject Mating;
    [SerializeField] GameObject Goodboy;
    [SerializeField] GameObject Missing;
    [SerializeField] GameObject LoseFight;
    
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
        else if (death == "Good Boy")
        {
            Goodboy.SetActive(true);
        }
        else if (death == "Missing")
        {
            Missing.SetActive(true);
        }
        else if (death == "Kucing Jahat")
        {
            LoseFight.SetActive(true);
        }
        
        


        

    }

  

    

    
}

