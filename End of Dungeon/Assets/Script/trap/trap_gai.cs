﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_gai : MonoBehaviour
{
    // Start is called before the first frame update
    public player player;
    public int damage = 1;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(damage);
            player.Knockback(100f, player.transform.position);
        }
    }
}
