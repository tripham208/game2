using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public int Levelload = 1;//screne
    public gamemaster gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))// chạm người chơi sẽ lưu điểm /chuyển màn
        {
            savescore();
           // gm.Inputtext.text = ("Press E to enter");
            SceneManager.LoadScene(Levelload);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {/*
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                savescore();
                SceneManager.LoadScene(Levelload);
            }
        }*/
    }

    private void OnTriggerExit2D(Collider2D col)
    { /*
        if (col.CompareTag("Player"))
        {
            gm.Inputtext.text = ("");
        }*/
    }

    void savescore()//lưu điểm
    {
        PlayerPrefs.SetInt("points", gm.points);
    }
}
