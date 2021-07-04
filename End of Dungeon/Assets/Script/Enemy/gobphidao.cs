using UnityEngine;

public class gobphidao : MonoBehaviour
{
    // Start is called before the first frame update
    public int curHealth = 100;

    public float distance;//khoangr cachs voi nguoi choi
    public float wakerange;//khoang cach tinh
    public float shootinterval;//chu kỳ tấn công
    public float bulletspeed = 5;//tốc độ
    public float bullettimer;

    public bool awake = false;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootL;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("attack", awake);

        RangeCheck();

        if (curHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void RangeCheck()//kiểm tra khoảng cách với người chơi
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;
    }

    public void Attack()//tấn công
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)//time chờ đủ
        {
            Vector2 direction = target.transform.position - transform.position;//trụ-người chơi
            direction.Normalize();//bình thường hóa

            GameObject bulletclone;
            bulletclone = Instantiate(bullet, shootL.transform.position, shootL.transform.rotation) as GameObject;
            bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

            bullettimer = 0;
        }
    }

    public void Damage(int dmg)//bị tấn công
    {
        curHealth -= dmg;
        //gameObject.GetComponent<Animation>().Play("redflash");
    }
}