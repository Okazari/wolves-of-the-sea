
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitAnimation : MonoBehaviour
{
  private Animator animator;
  // Start is called before the first frame update
  void Start()
  {
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
    }
  }
}
