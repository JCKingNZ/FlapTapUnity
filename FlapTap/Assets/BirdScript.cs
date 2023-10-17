using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //Making variables
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject pipeSpawner;
    public Sprite wingsUp;
    public Sprite wingsDown;

    // Start is called before the first frame update
    void Start()
    {
        //Links the birdscript to the logic script
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawner.SetActive(false);

        //StartCoroutine(waiter());

        /*
        for(int i = 0; i < iterationCount; i++)
        {
            invoke "changeSprite";
        }*/
    }

    /*
    void changeSprite()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite = wingsDown);
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wingsUp;
        }

        else 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wingsDown;
        }

    }
    */

    /* IEnumerator waiter()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = wingsUp;

        yield return new WaitForSeconds(0.1F);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = wingsDown;
    }
    */


    // Update is called once per frame
    void Update()
    {   
        //Takes the players input and moves the bird
        if ( Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            pipeSpawner.SetActive(true);

        }
        //If the bird goes below y -12 than the game is over
        if (transform.position.y < -12 || transform.position.y > 13 )
        {
            logic.gameOver();
            birdIsAlive = false;
        }

    }
    //If the bird hits a pipe the game is over
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

}
