using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpAudio : MonoBehaviour
{
    [SerializeField] AudioSource key;
    [SerializeField] AudioSource coin;

    private void keyPlay()
    {
        key.Play();
    }
    private void coinPlay()
    {
        coin.Play();
    }

}
