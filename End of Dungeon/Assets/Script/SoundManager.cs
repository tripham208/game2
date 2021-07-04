using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip coins, swords, destroy;

    public AudioSource adisrc;
    // Use this for initialization
    void Start()
    {
        //lấy nguồn audio
        coins = Resources.Load<AudioClip>("Gamecoin");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("RockCrash");
        adisrc = GetComponent<AudioSource>();
        adisrc.clip = coins;
        adisrc.PlayOneShot(coins, 1f);

    }

    public void Playsound(string clip)//phát nhạc
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
