using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    public GameManager myGameManager;
    public GameObject Bullet;
    private int index = 0;
    private Rigidbody2D myrigidbody2d;
    private SpriteRenderer mySpriterenderer;
   

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2d=GetComponent<Rigidbody2D>();
        mySpriterenderer=GetComponent<SpriteRenderer>();
        myGameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(WalkCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2d.velocity = new Vector2(myrigidbody2d.velocity.x,playerJumpForce);

        }
        myrigidbody2d.velocity = new Vector2(playerSpeed, myrigidbody2d.velocity.y);

        if (Bullet == null) return;
        if (Input.GetKeyDown(KeyCode.E))

        {
            Instantiate(Bullet, transform.position, Quaternion.identity);

        }

        
    }
    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriterenderer.sprite = mySprites[index];
        index++;
        if (index==5)
        {
            index = 0;

        }
        StartCoroutine(WalkCoRoutine());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }


    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
