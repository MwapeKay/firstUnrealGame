using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChangeAnimationScript : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    RuntimeAnimatorController jumpAnimation;
    RuntimeAnimatorController slideAnimation;
    bool isGrounded;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

        // Load jump and slide animations from resources
        jumpAnimation = Resources.Load("Animations/Jump_Animation_Controller") as RuntimeAnimatorController;
        slideAnimation = Resources.Load("Animations/Slide_Animation_Controller") as RuntimeAnimatorController;
    }

    void Update()
    {
        // Check for jump input and perform jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Check for slide input and perform slide
        if (Input.GetButtonDown("Slide"))
        {
            Slide();
        }
    }

    void FixedUpdate()
    {
        // Perform other game logic, e.g., movement
    }

    void Jump()
    {
        // Trigger jump animation
        myAnimator.runtimeAnimatorController = jumpAnimation;
        // Perform jump logic
        // Set isGrounded to false to prevent double jumps if needed
    }

    void Slide()
    {
        // Trigger slide animation
        myAnimator.runtimeAnimatorController = slideAnimation;
        // Perform slide logic
    }

    // Detect if the player is grounded
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
