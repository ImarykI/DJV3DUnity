using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;

    private void Start()
    {
        StartCoroutine(PlayTracks());
    }

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        } else DontDestroyOnLoad(gameObject);
    }

    IEnumerator PlayTracks()
    {
        AudioSource source = GetComponent<AudioSource>();
        int currentlyPlayingClip = 0;
        while (true)
        {
            source.clip = audioClips[currentlyPlayingClip++];
            source.Play();

            yield return new WaitForSeconds(source.clip.length);
            if (currentlyPlayingClip >= audioClips.Length) currentlyPlayingClip = 0;
        }

    }
}

public sealed class Singleton
{
    private Singleton() { }
    private static Singleton _instance;

    public static Singleton GetInstance()
    {
        if( _instance == null ) _instance = new Singleton();
        return _instance;
    }

    public void BusinessLogic() { }

}