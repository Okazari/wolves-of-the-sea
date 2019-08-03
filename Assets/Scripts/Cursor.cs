using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Cursor : MonoBehaviour
{

  private GameObject instance;
  private Rigidbody2D rigidbody;

  private Vector2 moveInput;
  private float horizontalAxis;
  private float verticalAxis;

  private string direction;
  private float sensibility = 1f;

  public Boolean locked = false;

  public float minimumMoveDeltaTimer;

  void resetMinimumMoveDeltaTimer()
  {
    this.minimumMoveDeltaTimer = 0.1f;
  }

  void Start()
  {
    resetMinimumMoveDeltaTimer();
    instance = new GameObject("Cursor");
    instance.transform.position = new Vector2(2, 2);
    RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>("cursor/CursorAnimatorController");
    SpriteRenderer cursorSpriteRenderer = instance.AddComponent<SpriteRenderer>();
    cursorSpriteRenderer.sortingLayerName = "cursor";
    Animator animator = instance.AddComponent<Animator>();
    this.rigidbody = instance.AddComponent<Rigidbody2D>();
    this.rigidbody.isKinematic = true;
    animator.runtimeAnimatorController = animatorController;
  }

  void Update()
  {
    this.horizontalAxis = Input.GetAxisRaw("Horizontal");
    this.verticalAxis = Input.GetAxisRaw("Vertical");
    if (minimumMoveDeltaTimer <= 0)
    {
      if (horizontalAxis >= sensibility)
      {
        direction = "left";
      }
      else if (horizontalAxis <= -sensibility)
      {
        direction = "right";
      }
      else if (verticalAxis >= sensibility)
      {
        direction = "up";
      }
      else if (verticalAxis <= -sensibility)
      {
        direction = "down";
      }
      else
      {
        direction = null;
      }
    }
  }


  void FixedUpdate()
  {
    minimumMoveDeltaTimer -= Time.deltaTime;
    Debug.Log(minimumMoveDeltaTimer);
    Debug.Log(direction);
    if (direction != null && minimumMoveDeltaTimer <= 0)
    {
      switch (direction)
      {
        case "up":
          if (this.instance.transform.localPosition.y < 9 - 1)
            this.instance.transform.localPosition = Vector2.MoveTowards(this.instance.transform.localPosition, new Vector2(this.instance.transform.localPosition.x, this.instance.transform.localPosition.y + 1), 1);
          break;
        case "down":
          if (this.instance.transform.localPosition.y > 0)
            this.instance.transform.localPosition = Vector2.MoveTowards(this.instance.transform.localPosition, new Vector2(this.instance.transform.localPosition.x, this.instance.transform.localPosition.y - 1), 1);
          break;
        case "left":
          if (this.instance.transform.localPosition.x < 9 - 1)
            this.instance.transform.localPosition = Vector2.MoveTowards(this.instance.transform.localPosition, new Vector2(this.instance.transform.localPosition.x + 1, this.instance.transform.localPosition.y), 1);
          break;
        case "right":
          if (this.instance.transform.localPosition.x > 0)
            this.instance.transform.localPosition = Vector2.MoveTowards(this.instance.transform.localPosition, new Vector2(this.instance.transform.localPosition.x - 1, this.instance.transform.localPosition.y), 1);
          break;
        default:
          break;
      }
      direction = null;
      resetMinimumMoveDeltaTimer();
    }
  }


}
