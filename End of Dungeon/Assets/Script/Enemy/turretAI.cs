using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour
{
    // Start is called before the first frame update
    public int curHealth = 100;

    public float distance;//khoangr cachs voi nguoi choi
    public float wakerange;//khoang cach tinh
    public float shootinterval;//chukỳ tấn công
    public float bulletspeed = 5;//tốc độ
    public float bullettimer;

    public bool awake = false;
    public bool lookingRight = false;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootL, shootR;


    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("awake", awake);
        anim.SetBool("Right", lookingRight);

        RangeCheck();

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }

        if (curHealth < 0)
        {
            Destroy(gameObject);
        }
    }


    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;
    }

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)
        {
            Vector2 direction = target.transform.position - transform.position;//trụ-người chơi
            direction.Normalize();

            if (attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootR.transform.position, shootR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }

            if (!attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootL.transform.position, shootL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }
        }
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("redflash");
    }
}
