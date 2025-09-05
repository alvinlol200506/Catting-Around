using UnityEngine;
using UnityEngine.SceneManagement;

public class BreedingScript : InteractionTrigger
{


    [SerializeField] GameObject lope1;
     [SerializeField] GameObject lope2;
     [SerializeField] GameObject lope3;
     [SerializeField] GameObject lope4;
     [SerializeField] SoundEffectScript ses;

    int BreedCount;
    public EndingImagesSO so;
    public override void InteractTrigger()
    {
        Breed();
    }



    public void Breed()
    {
        BreedCount++;
        ses.breedEffect();

        if (BreedCount == 1)
            lope1.SetActive(true);
        else if (BreedCount == 2)
            lope2.SetActive(true);
        else if (BreedCount == 3)
            lope3.SetActive(true);
        else if (BreedCount == 4)
            lope4.SetActive(true);            

        if (BreedCount >= 5)
        {
            so.ending = "Mating";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
