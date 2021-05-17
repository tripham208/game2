using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    // Start is called before the first frame update
    public gobphidao turret;//đối tượng tấn công
   


    private void Awake()
    {
        turret = gameObject.GetComponentInParent<gobphidao>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
                turret.Attack();


        }
    }
}
