using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundManager", menuName = "ScriptableObjects/SoundManager")]

public class SoundManagerSO : ScriptableObject
{
    public bool isSoundOn;
    public float volume;
    public float pitch;
    public AudioSource audioSource;
}
