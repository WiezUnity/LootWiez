using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public Animator animator;
    public Transform teleportationLocation;
    public GameObject player;
    public float telespeed;
    public GameObject Enemy;
    public Transform teleportationLocationEnemy;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            transform.position = Vector2.MoveTowards(transform.position, teleportationLocation.position, telespeed * Time.deltaTime);
            Instantiate(Enemy, teleportationLocationEnemy.position, Quaternion.identity);
        }
    }

}
