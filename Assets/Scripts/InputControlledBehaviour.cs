
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputControlledBehaviour : MonoBehaviour
{

  private float speed = 10;
  private Vector2 moveVelocity;
  private Rigidbody2D rb;

  private Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    this.rb = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    float horizontalAxis = Input.GetAxisRaw("Horizontal");
    float verticalAxis = Input.GetAxisRaw("Vertical");
    if (horizontalAxis == 0 && verticalAxis == 0)
    {
      animator.Play("idle");
      Vector2 moveInput = new Vector2(horizontalAxis, verticalAxis);
      this.moveVelocity = moveInput.normalized * speed;
    }
    else if (Mathf.Abs(horizontalAxis) > Mathf.Abs(verticalAxis))
    {
      if (horizontalAxis < 0)
      {
        animator.Play("left");
      }
      else
      {
        animator.Play("right");
      }

      Vector2 moveInput = new Vector2(horizontalAxis, 0);
      this.moveVelocity = moveInput.normalized * speed;
    }
    else
    {
      if (verticalAxis < 0)
      {
        animator.Play("down");
      }
      else
      {
        animator.Play("up");
      }

      Vector2 moveInput = new Vector2(0, verticalAxis);
      this.moveVelocity = moveInput.normalized * speed;
    }
  }

  void FixedUpdate()
  {
    this.rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
  }

}
