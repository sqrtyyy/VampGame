using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    //direction
    protected bool isFacingRight = true;

    private float delayToIdle = 0.0f;

    //link to animation component
    protected Animator anim;

    protected Rigidbody2D body2D;

    protected float maxSpeed;

    protected int health;

    protected int viewRadius;

    protected float attackDamage;



    public Character() {}


    /// <summary>
    /// Initial initialization
    /// </summary>
	protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// We perform actions in the FixedUpdate method, since in the Animator component of the character
    /// set to Animate Physics = true and animation is synchronized with physics calculations
    /// </summary>
    protected virtual void FixedUpdate()
    {
        // use Input.GetAxis for the X axis. The method returns the axis value in the range from -1 to 1.
        // with standard project settings
        // - 1 is returned when you press the left arrow (or the A key) on the keyboard,
        // 1 is returned when pressing the right arrow (or the D key) on the keyboard
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // refer to the character component RigidBody2D. set its speed along the X axis,
        // equal to the X axis value multiplied by the max. speed
        body2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        //body2D.velocity = new Vector2(moveX * maxSpeed, body2D.velocity.y);

        // if you pressed the key to move to the right, and the character is directed to the left
        if (moveX > 0 && !isFacingRight)
            // flip the character to the right
            Flip();
        // reverse situation. flip the character to the left
        else if (moveX < 0 && isFacingRight)
            Flip();


        // -- Handle Animations --

        //Death
        if (Input.GetKeyDown("e")) {
            anim.SetTrigger("death");
        }

        //Hurt
        else if (Input.GetKeyDown("q")) {
            anim.SetTrigger("hurt");
        }

        //Attack
        else if (Input.GetMouseButtonDown(0)) {
            anim.SetTrigger("attack");
        }

        //Run
        else if (Mathf.Abs(moveX) > Mathf.Epsilon || Mathf.Abs(moveY) > Mathf.Epsilon) {
            // Reset timer
            delayToIdle = 0.05f;
            anim.SetInteger("animState", 1);
        }

        //Idle
        else {
            // Prevents flickering transitions to idle
            delayToIdle -= Time.deltaTime;
            if (delayToIdle < 0)
                anim.SetInteger("animState", 0);
        }

    }


    private void Flip()
    {
        // change the direction of movement of the character
        isFacingRight = !isFacingRight;
        // get the size of the character
        Vector3 theScale = transform.localScale;
        // flip the character along the X axis
        theScale.x *= -1;
        // set the new character size equal to the old one, but mirrored
        transform.localScale = theScale;
    }
}