using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip Sound;
    private Rigidbody2D MyRigidBody2D;
    public float bulletSpeed;
    public GameManager myGameManager;
    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindAnyObjectByType<GameManager>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        

    }

    // Update is called once per frame
    void Update()
    {
        MyRigidBody2D.velocity = new Vector2(bulletSpeed, MyRigidBody2D.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ItemBad"))
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
        }
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
}
