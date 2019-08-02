using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

  public static GameManager instance;


  private BattleManager battleManager;

  private int columns = 8;
  private int rows = 8;

  // Start is called before the first frame update
  void Awake()
  {
    if (instance == null)
      instance = this;
    else if (instance != this)
      Destroy(gameObject);
    //Sets this to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);
    //Get a component reference to the attached BoardManager script
    battleManager = gameObject.AddComponent<BattleManager>();
    // battleManager.transform.SetParent(gameObject.transform);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
