using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG : MonoBehaviour {

    [Header("傷害"), Range(0, 200)]
    public float damage = 150;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            collision.gameObject.GetComponent<player>().Damage(damage);
        }
    }


}
