using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public int health;
    public int maxHealth=10;
    public int CatnipMeter = 0;
    public bool wet;
    public Image healthbar;
    RectTransform fillrect;



    public void HealthEdit(int x)
    {
        health += x;
        if (health <= 0)
        {
            Debug.Log("death");
        }

        updatebar();
        
    }
    void Start()
    {
        fillrect = healthbar.rectTransform;
        health = maxHealth;
        updatebar();
    }

    void updatebar() { 
        float ratio = (float)health / maxHealth;
        var size = fillrect.sizeDelta;
        size.x = ratio * 158.42f;
        fillrect.sizeDelta = size;
    }









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
