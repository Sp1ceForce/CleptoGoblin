using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpAudio : MonoBehaviour
{
    [SerializeField] AudioSource key;
    [SerializeField] AudioSource coin;
    [SerializeField] AudioSource guard;
    [SerializeField] AudioSource goblin;
    public bool goblStat = false;

    private void keyPlay()
    {
        key.Play();
    }
    private void coinPlay()
    {
        coin.Play();
    }

    private void Goblin()
    {

        if (goblStat == true)
        {
            goblin.PlayDelayed(0.4f);
            guard.Stop();
            goblStat = false;
        }
    }
    private void Guard()
    {
        if (goblStat == false)
        {
            guard.PlayDelayed(0.4f);
            goblin.Stop();
            goblStat = true;
        }
    }
}
