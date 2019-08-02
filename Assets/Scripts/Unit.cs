
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
  protected SpriteRenderer sr;
  protected GameObject instance;
  protected Rigidbody2D rigidBody;

  protected Animator animator;

  protected SpriteSwapDemo spriteSwap;

  public Unit(string spriteSheetName)
  {

    this.instance = new GameObject();
    var test = Resources.Load<RuntimeAnimatorController>("UnitAnimationController");
    this.sr = instance.AddComponent<SpriteRenderer>();
    this.animator = instance.AddComponent<Animator>();
    this.animator.runtimeAnimatorController = test;
    this.spriteSwap = instance.AddComponent<SpriteSwapDemo>();
    this.spriteSwap.SpriteSheetName = spriteSheetName;
    this.rigidBody = instance.AddComponent<Rigidbody2D>();
    this.rigidBody.isKinematic = true;
  }
}
