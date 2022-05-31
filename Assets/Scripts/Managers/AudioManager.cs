using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public SoundManagerSO soundManagerSO;



    private void Start()
    {
        soundManagerSO.audioSource = audioSource; 
    }
}
