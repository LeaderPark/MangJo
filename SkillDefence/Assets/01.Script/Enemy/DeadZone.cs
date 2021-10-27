using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollision2D(Collision2D col) {
        if(col.gameObject.tag == "Enemy"&&col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
