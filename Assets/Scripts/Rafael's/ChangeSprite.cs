using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    

    public Sprite FirstState; 
    public Sprite SecondState; 
    private SpriteRenderer spriteRenderer;
    private bool first=true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void toggleSprite()
    {
        Debug.Log("toggled");
        if (spriteRenderer != null)
        {
            if (!first)
                spriteRenderer.sprite = FirstState;
            else
                spriteRenderer.sprite = SecondState;

            first = !first;
        }
    }

    
}
