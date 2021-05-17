using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartui : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Heartsprite;

    public player player;

    public Image Heart;

    // Use this for initialization
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.ourHealth > 5)
            player.ourHealth = 5;

        if (player.ourHealth < 0)
            player.ourHealth = 0;

        Heart.sprite = Heartsprite[player.ourHealth];
    }
}