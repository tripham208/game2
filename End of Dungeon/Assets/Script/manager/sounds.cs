using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioClip coins, swords, destroy;

    public AudioSource adisrc;
    // Use this for initialization
    void Start()
    {
        coins = Resources.Load<AudioClip>("Gamecoin");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("RockCrash");
        adisrc = GetComponent<AudioSource>();

    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;

            case "sword":
                adisrc.clip = swords;
                adisrc.PlayOneShot(swords, 1f);
                break;

        }
    }
}
