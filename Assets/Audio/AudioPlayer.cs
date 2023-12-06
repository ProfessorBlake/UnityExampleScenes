using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
