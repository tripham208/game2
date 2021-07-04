using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    // Start is called before the first frame update
    public player player;
    public movingflat mov;

    public Vector3 movep;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<player>();
        mov = GameObject.FindGameObjectWithTag("Movingflat").GetComponent<movingflat>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //đứng trên vật thể 
        if (collision.isTrigger == false)
            player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //nếu đứng trên bậc di chuyển thì nhân vân di chuyển theo
        if (collision.isTrigger == false && collision.CompareTag("Movingflat"))
        {
            movep = player.transform.position;
            movep.x += mov.speed * 1.5f;
            player.transform.position = movep;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.isTrigger == false || collision.CompareTag("water"))
       //     player.grounded = false;
    }
}
