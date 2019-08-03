using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BattleGrid
{

  private int nbColumns;
  private int nbRows;

  private List<List<Cell>> gridPositions;

  public class Cell
  {
    public GameObject instance;
    public GameObject grid;
    public Cell(int x, int y)
    {
      this.instance = new GameObject($"Cell {x}-{y}");
      instance.transform.position = new Vector2(x, y);
      SpriteRenderer spriteRenderer = this.instance.AddComponent<SpriteRenderer>();
      Sprite[] sprites = Resources.LoadAll<Sprite>("map/grass");
      spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
      spriteRenderer.sortingLayerName = "background";

      this.grid = new GameObject("Grid overlay");
      this.grid.transform.SetParent(this.instance.transform);
      this.grid.transform.localPosition = new Vector2(0, 0);
      SpriteRenderer gridRenderer = this.grid.AddComponent<SpriteRenderer>();
      gridRenderer.sprite = Resources.Load<Sprite>("grid");
      gridRenderer.sortingLayerName = "grid";
      gridRenderer.color = new Color(255, 255, 255, 0.2f);
    }
  }

  public BattleGrid(int nbColumns, int nbRows, GameObject parent)
  {
    this.nbColumns = nbColumns;
    this.nbRows = nbRows;
    this.gridPositions = Enumerable.Range(0, nbColumns).Select(x =>
    {
      return Enumerable.Range(0, nbRows).Select(y =>
      {
        Cell tile = new Cell(x, y);
        tile.instance.transform.SetParent(parent.transform);
        return tile;
      }).ToList();
    }).ToList();
  }

  Cell getCell(int x, int y)
  {
    return this.gridPositions[x][y];
  }
}
