using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flat : MonoBehaviour//lên xuống
{
    public Rigidbody2D r2;
    public float timedelay = 2;//time

    // Use this for initialization
    private void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)//va chạm với compiler khác
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }

    private IEnumerator fall()//rơi
    {
        yield return new WaitForSeconds(timedelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}