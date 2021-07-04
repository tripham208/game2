using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float Attackdelay = 0.3f;
    public bool Attacking = false;

    public Animator anim;

    public Collider2D trigger;
    public sounds sound;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<sounds>();//get âm thanh tấn công
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !Attacking)//phím z tấn công
        {
            Attacking = true;
            trigger.enabled = true;
            Attackdelay = 0.3f;
            sound.Playsound("sword");
        }

        if (Attacking)//đang tấn công
        {
            if (Attackdelay > 0)//vẫn time chờ
            {
                Attackdelay -= Time.deltaTime;

            }
            else
            {
                Attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attack", Attacking);
    }
}
