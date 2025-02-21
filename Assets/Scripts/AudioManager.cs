using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundEffects;
    public AudioSource music;

    public AudioClip treeCollision;
    public AudioClip hospitalDropOff;
    public AudioClip soldierPickup;
    public AudioClip windGust;
    public AudioClip youWin;

    void PlaySound(AudioClip clip)
    {
        soundEffects.clip = clip;
        soundEffects.Play();
    }

    public void PlayTreeCollision()
    {
        PlaySound(treeCollision);
        music.mute = true;
        StartCoroutine(MuteAfterSound(soundEffects, treeCollision.length));
    }

    private IEnumerator MuteAfterSound(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.mute = true;
    }

    public void PlayHospitalDropOff()
    {
        PlaySound(hospitalDropOff);
    }

    public void PlaySoldierPickup()
    {
        PlaySound(soldierPickup);
    }

    public void PlayWindGust()
    {
        PlaySound(windGust);
    }

    public void PlayYouWin()
    {
        PlaySound(youWin);
        music.mute = true;
        StartCoroutine(MuteAfterSound(soundEffects, youWin.length));
    }
}
