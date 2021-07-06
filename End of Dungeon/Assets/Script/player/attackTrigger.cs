using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg = 200;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //tấn công vào quái sẽ gây sát thương cho quái
        if (col.isTrigger != true && col.CompareTag("Enemy")) 
        {
            //thực hiện phương thức ,chuyền biến
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
