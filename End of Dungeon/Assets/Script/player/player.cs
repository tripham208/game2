using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 3, jumpPow = 400f, maxjump = 8;//tốc độ ,tốc tối đa, lực nhảy
    public bool grounded = true, faceright = true, jump2 = false;
    //mặt đất/quay phải/ nhảy 2 lần
    public int ourHealth;//máu hiện tại
    public int maxhealth = 5;//máu tối đa

    public Rigidbody2D r2;
    public Animator anim;
    public gamemaster gm;
    public sounds sound;
    // Use this for initialization
    private void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        ourHealth = maxhealth;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<sounds>();
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("Ground", grounded); //thiết lập giá trị ground  //bieens  cuar minh tao
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));//thiết lập giá trị tốc độ, (dương)

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                jump2 = true;
                r2.AddForce(Vector2.up * jumpPow);//up :nhay : y
            }
            else
            {
                if (jump2)//nháy 2 lần lực nhay giảm
                {
                    jump2 = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.5f);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");//di chuyển ngang
        //update =>hướng đi
        r2.AddForce((Vector2.right) * speed * h);//lực ,ảnh hưởng di chuyển
        //giới hạn tốc độ
        if (r2.velocity.x > maxspeed)//phải
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)//trái
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
       /* if (r2.velocity.y > maxjump)
             r2.velocity = new Vector2(r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
             r2.velocity = new Vector2(r2.velocity.x, -maxjump);*/
        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);//giảm tốc độ khi trên mặt đất :y ko đổi ,v=70%5
        }
        if (ourHealth <= 0)//máu <0 chết
        {
            Death();
        }
    }

    public void Flip()//xoay chiều khi đi ngược lại
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;//xoay chieu
        transform.localScale = Scale;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highscore") < gm.points) 
            PlayerPrefs.SetInt("highscore", gm.points);
    }
    public void Damage(int damage)//bị sát thương
    {
        ourHealth -= damage;
        //gameObject.GetComponent<Animation>().Play("redflash");
    }

    public void Knockback(float Knockpow, Vector2 Knockdir)//đẩy lùi
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -50, Knockdir.y*0.15f * Knockpow));
    }
    private void OnTriggerEnter2D(Collider2D col)//khi cchạm vật thêr
    {
        if (col.CompareTag("Coins"))//ăn vàng cộng điểm
        {
            
            Destroy(col.gameObject);
            gm.points += 1;
            sound.Playsound("coins");
        }
        if (col.CompareTag("giay"))//ăn giày tăng tốc
        {

            Destroy(col.gameObject);
            maxspeed = 6f;
            speed = 100f;
            StartCoroutine(timecount(5));//đếm time tác dụng
        }
    }
    IEnumerator timecount(float time)//đếm time tác dụng
    {
        yield return new WaitForSeconds(time);
        maxspeed = 3f;
        speed = 50f;
        yield return 0;
    }
}
