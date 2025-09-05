using UnityEngine;

public class SoundtrackScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip rumah;
    public AudioClip taman;

    public AudioSource AS;


    public void Start()
    {
        AS = GetComponent<AudioSource>();
        togglesound();
    }

    private bool dalamrumah = true;
    public void togglesound()
    {
        if (dalamrumah)
            SoundRumah();
        else
            SoundTaman();

        dalamrumah = !dalamrumah;
    }

    public void SoundRumah()
    {
        AS.Stop();
        AS.clip = rumah;
        AS.Play();
    }

    public void SoundTaman()
    {
        AS.Stop();
        AS.clip = taman;
        AS.Play();
    }

}
