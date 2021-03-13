using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterInput controller;
    //direction
    protected bool isFacingRight = true;

    private float delayToIdle = 0.0f;

    private float timeSinceAttack = 0.0f;

    //link to animation component
    protected Animator anim;

    protected Rigidbody2D body2D;

    protected float maxSpeed;

    protected int health;

    protected int viewRadius;

    protected float attackDamage;


    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }

    private void Awake()
    {
        controller = new CharacterInput();
        controller.Player.Atack.performed += ctx => Attack();
        controller.Player.Die.performed += ctx => { anim.SetTrigger("death"); };
        controller.Player.Hurt.performed += ctx => { anim.SetTrigger("hurt"); };
    }

    private void Move(Vector2 direction)
    {
        float moveX = direction.x;
        float moveY = direction.y;

        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }
        else
        {
            body2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

            if (Mathf.Abs(moveX) > Mathf.Epsilon || Mathf.Abs(moveY) > Mathf.Epsilon)
            {
                // Reset timer
                delayToIdle = 0.05f;
                anim.SetInteger("animState", 1);
            }
            else
            {
                // Prevents flickering transitions to idle
                delayToIdle -= Time.deltaTime;
                if (delayToIdle < 0)
                    anim.SetInteger("animState", 0);
            }
        }

    }

    private void Attack()
    {
        if (timeSinceAttack > 0.45)
        {
            anim.SetTrigger("attack");

            // Reset timer
            timeSinceAttack = 0.0f;
        }
    }
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
    protected virtual void Update()
    {
        timeSinceAttack += Time.deltaTime;
        Move( controller.Player.Move.ReadValue<Vector2>());
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