using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class player : MonoBehaviour {

    [Header("移動速"), Range(0, 1000)]
    public int speed = 50;

    [Header("跳躍高"), Range(0, 2000)]
    public float jump = 2.5f;

    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    [Header("血量條")]
    public Image hpBar;

    [Header("結束畫")]
    public GameObject final;

    private Rigidbody2D rigbody2d;
    private Animator anima;
    private bool onGround;
    private float hpMax;


    private void Start()
    {
        
        rigbody2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

        hpMax = hp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        Jump();
    }

    private void FixedUpdate()
    {
        Walk(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" )
        {
            onGround = true;
            anima.SetBool("jump", false);
        }
    }


    private void Walk()
    {
        if (rigbody2d.velocity.magnitude < 10)
            rigbody2d.AddForce(new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0));
            anima.SetBool("run", Input.GetAxisRaw("Horizontal") != 0);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            onGround = false;
            rigbody2d.AddForce(new Vector2(0, jump));
            anima.SetBool("jump", true);
        }
    }

    private void Turn(int direction = 0)
    {
        this.transform.eulerAngles = new Vector3(0, direction, 0);
    }


    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;

        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        final.SetActive(true);
    }

}
