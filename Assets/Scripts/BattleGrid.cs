using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BattleGrid
{

  private int nbColumns;
  private int nbRows;

  private List<List<GameObject>> gridPositions;

  public BattleGrid(int nbColumns, int nbRows, GameObject parent)
  {
    this.nbColumns = nbColumns;
    this.nbRows = nbRows;
    this.gridPositions = Enumerable.Range(0, nbColumns).Select(x =>
    {
      return Enumerable.Range(0, nbRows).Select(y =>
      {
        var tile = new GameObject($"Cell {x}-{y}");
        tile.transform.position = new Vector2(x, y);
        SpriteRenderer spriteRenderer = tile.AddComponent<SpriteRenderer>();
        Dictionary<string, Sprite> sprites = Resources.LoadAll<Sprite>("battleBackground").ToDictionary(sp => sp.name, sp => sp); ;
        Debug.Log(sprites);
        spriteRenderer.sprite = sprites["grass"];
        tile.transform.SetParent(parent.transform);
        return tile;
      }).ToList();
    }).ToList();
  }

  GameObject getCell(int x, int y)
  {
    return this.gridPositions[x][y];
  }
}
