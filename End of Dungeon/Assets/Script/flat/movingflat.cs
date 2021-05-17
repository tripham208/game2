using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingflat : MonoBehaviour
{
    public float speed = 0.02f, changeDirection = -1;

    private Vector3 Move;
    public menu pausep;

    // Use this for initialization
    private void Start()
    {
        Move = this.transform.position;
        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<menu>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pausep.pause)
        {
            this.transform.position = this.transform.position;//dừng ko đổi
        }
        if (pausep.pause == false)
        {
            Move.x += speed;//vị trí x + speed
            this.transform.position = Move;// di chuyển
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("ground"))
        {
            speed *= changeDirection;
        }
    }
}