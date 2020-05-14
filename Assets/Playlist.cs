using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public Component[] arrayMusic;
    public AudioSource[] playlist;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        playlist = this.GetComponents<AudioSource>();
        //foreach (AudioSource music in arrayMusic)
        //playlist = music;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!playlist[i].isPlaying)
        {
            i++;
            if (i > 1)
                i = 0;
            playlist[i].Play();
        }
    }
}
