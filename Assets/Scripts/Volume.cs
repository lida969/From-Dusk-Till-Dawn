using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField]  private AudioSource audioSrc;
    private float musicVolume = 1f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
