using System;
using System.Diagnostics;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        String death = DeathData.causeOfDeath;

        switch (death)
        {
            case "High":
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    
}
