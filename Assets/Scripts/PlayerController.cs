using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

      if (
         Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
         Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
         {
          animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
          animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
         }
    }
    
    void FixedUpdate()
    {
      if (Input.GetKey("left shift"))
      { speed = 2.2f; }

      else
      { speed = 1.3f; }

      rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
   }
}