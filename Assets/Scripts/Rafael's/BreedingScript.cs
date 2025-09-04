using UnityEngine;
using UnityEngine.SceneManagement;

public class BreedingScript : InteractionTrigger
{

    int BreedCount;
    public EndingImagesSO so;
    public override void InteractTrigger()
    {
        Breed();
    }



    public void Breed()
    {
        BreedCount++;
        if (BreedCount >= 5)
        {
            so.ending = "Mating";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
