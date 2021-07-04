using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartui : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Heartsprite;//mảng hình ảnh hiện mạng

    public player player;

    public Image Heart;// ảnh hiện số mạng cnf lại

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

        Heart.sprite = Heartsprite[player.ourHealth];//hình ảnh tương ứng
    }
}