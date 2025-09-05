using UnityEngine;

public class SoundEffectScript : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip lick;
    public AudioClip damage;
    public AudioClip attack;
    public AudioClip breed;
    public AudioClip window;
    public AudioClip toilet;
    public AudioClip pintu;
    public AudioSource AS;


    public void Start()
    {
        AS = GetComponent<AudioSource>();

    }


    public void jumpEffect()
    {
        AS.Stop();
        AS.clip = jump;
        AS.Play();
    }

    public void lickEffect()
    {
        AS.Stop();
        AS.clip = lick;
        AS.Play();
    }

    public void damageEffect()
    {
        AS.Stop();
        AS.clip = damage;
        AS.Play();
    }

    public void attackEffect()
    {
        AS.Stop();
        AS.clip = attack;
        AS.Play();
    }

    public void breedEffect()
    {
        AS.Stop();
        AS.clip = breed;
        AS.Play();
    }

    public void windowEffect()
    {
        AS.Stop();
        AS.clip = window;
        AS.Play();
    }

    public void toiletEffect()
    {
        AS.Stop();
        AS.clip = toilet;
        AS.Play();
    }
    public void pintuEffect()
    {
         AS.Stop();
        AS.clip = pintu;
        AS.Play();
     }
}
