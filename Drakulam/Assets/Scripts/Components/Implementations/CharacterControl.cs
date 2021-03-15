using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : IControllable
{
    
    private CharacterInput controller;
    private Rigidbody2D body2D;
    
    private bool isFacingRight = true;
    
    [SerializeField] float maxSpeed = 10;
    
    private float delayToIdle = 0.0f;
    
    protected Animator anim; 
    
    
    private void Awake()
    {
        controller = new CharacterInput();
        controller.Player.Die.performed += ctx => { anim.SetTrigger("death"); };
        controller.Player.Atack.performed += ctx =>
        {
            if (GetComponent<IDamageDealer>() != null)
            {
                GetComponent<IDamageDealer>().Attack();
            }
            else
            {
                Debug.Log("Object doesn't have component \"IDamageDealer\"");
            }
        };
        controller.Player.Hurt.performed += ctx =>
        {
            GetComponent<ITaskCompleter>().FindTask();
        };
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

    
    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }
    
    protected void Update()
    {
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
    
    protected void Start()
    {
        anim = GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();
        
    }
}
