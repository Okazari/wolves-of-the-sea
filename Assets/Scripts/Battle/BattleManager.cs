using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BattleManager : MonoBehaviour
{

  public int columns = 9;
  public int rows = 9;

  public List<Unit> playerUnits;
  private GameObject instance;

  public Cursor cursor;

  private BattleGrid battleGrid;
  void Awake()
  {
    instance = new GameObject("Battle");
    battleGrid = new BattleGrid(columns, rows, instance);
    cursor = instance.AddComponent<Cursor>();
    Unit unit = new Unit();
    unit.instance.transform.SetParent(instance.transform);
    playerUnits.Add(unit);
  }

}
