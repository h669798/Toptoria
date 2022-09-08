using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void LateUpdate()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    
    void FixedUpdate() {
      rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
