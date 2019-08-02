using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

  public Player me;

  public Transform tr;

  // Start is called before the first frame update
  void Start()
  {
    me = new Player("bigunit", new Vector2(2, 2));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
