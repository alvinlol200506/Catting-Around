using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{

    public int health=10;
    public int CatnipMeter = 0;
    public bool wet;
    















    public Dictionary<string, bool> interactedMap = new Dictionary<string, bool>();
    
   
    [SerializeField] private List<string> interactionIds = new List<string>(); // Akan tampil di Inspector

    public void RegisterInteraction(string id)
    {

        if (!interactedMap.ContainsKey(id))
        {
            interactedMap[id] = true; 
        }
        else
        {
            interactedMap[id] = !interactedMap[id]; 
        }

    interactionIds.Add(id);

    }




    public Dictionary<string, bool> GetInteractions()
    {
        return interactedMap;
    }


}
