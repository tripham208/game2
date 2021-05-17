using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float smoothtimeX, smoothtimeY;//time thay đổi

    public Vector2 velocity;

    public GameObject player;//chỉ người chơi

    public Vector2 minpos, maxpos;// set bằng giá trị nền max có thể trong map
    public bool bound;//giới hạn thay đổi khung hình

    // Use this for initialization
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        //hiện tại ->mục tiêu  ;this :camera
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bound)
        {//
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
                Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
                Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}