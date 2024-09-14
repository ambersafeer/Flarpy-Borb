using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource fall;
    public AudioSource flap;
    private int repetitions = 0;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            animator.SetTrigger("Flap");
            flap.Play();
        }
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (repetitions == 0)
        {
            animator.SetTrigger("Die");
            fall.Play();
        }
        logic.gameOver();
        birdIsAlive = false;
        repetitions++;
    }
}
