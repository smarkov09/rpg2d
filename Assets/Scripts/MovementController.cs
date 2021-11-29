using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2d;

    Animator animator;
    string animationState = "AnimationState";
    enum CharSates
    {
        walkEast = 1,
        walkWest = 2,
        block = 3,
        idle = 4
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2d.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int) CharSates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int) CharSates.walkWest);
        }
        else if (movement.y > 0 || movement.y < 0)
        {
            animator.SetInteger(animationState, (int) CharSates.block);
        }
        else
        {
            animator.SetInteger(animationState, (int) CharSates.idle);
        }
    }
}
