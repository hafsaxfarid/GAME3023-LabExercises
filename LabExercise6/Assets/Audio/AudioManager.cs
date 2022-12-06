using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrackID
{
    MainMenu,
    Town,
    Overworld,
    Battle,
    None
}

public class AudioManager : MonoBehaviour
{
    // Add in same order as TrackID
    [SerializeField]
    AudioClip[] musicTrackClips;

    [SerializeField]
    AudioSource audioSource1;

    [SerializeField]
    AudioSource audioSource2;

    public static AudioManager amInstance;

    private void Awake()
    {
        if (amInstance == null)
        {
            amInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource1.Play();
    }

    public void PlayAudio(TrackID trackID)
    {
        audioSource1.Stop();
        audioSource2.Stop();

        audioSource1.clip = musicTrackClips[(int)trackID];
        audioSource1.Play();
    }

    public void CrossFade(TrackID newTrackID, float duration)
    {
        AudioSource oldTrack = audioSource1;
        AudioSource newTrack = audioSource2;

        if (audioSource1.isPlaying)
        {
            oldTrack = audioSource2;
            newTrack = audioSource1;
        }

        newTrack.clip = musicTrackClips[(int)newTrackID];
        newTrack.Play();
    }
}
