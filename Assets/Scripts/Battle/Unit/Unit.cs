using UnityEngine;

public class Unit
{

  public GameObject instance;


  public Unit()
  {
    instance = new GameObject("Unit");
    instance.transform.position = new Vector2(1, 1 - 0.20f);
    RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>("IdleAnimatorController");
    SpriteRenderer unitSpriteRenderer = instance.AddComponent<SpriteRenderer>();
    unitSpriteRenderer.sortingLayerName = "units";
    Animator animator = instance.AddComponent<Animator>();
    animator.runtimeAnimatorController = animatorController;
  }


}
