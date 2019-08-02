using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

  Animator a;
  protected InputControlledBehaviour icb;

  public Player(string spriteSheetName, Vector2 position) : base(spriteSheetName)
  {
    this.sr.sprite = Resources.Load<Sprite>("unit");
    Transform t = this.instance.GetComponent<Transform>();
    t.localPosition = position;
    this.icb = instance.AddComponent<InputControlledBehaviour>();
  }
}