using UnityEngine;

public static class GridExtensions
{
   public static void DrawLevel(this Grid grid, LevelConfig levelConfig, CellConfigProvider cellConfigProvider)
   {
      CellConfig currentCellConfig;
      GameObject cellGo;
      
      var layer = grid.gameObject.layer;

      foreach (var cellConfig in levelConfig.Cells)
      {
         currentCellConfig =
            cellConfigProvider.GetConfig(cellConfig.CellConfigMin.CellType, cellConfig.CellConfigMin.CellSubType);
         DrawCell(grid, cellConfig.CellPosition, currentCellConfig, layer);
      }
      
      foreach (var modifierConfig in levelConfig.Modifiers)
      {
         currentCellConfig =
            cellConfigProvider.GetConfig(modifierConfig.CellConfigMin.CellType, modifierConfig.CellConfigMin.CellSubType);
         DrawCell(grid, modifierConfig.CellPosition, currentCellConfig, layer);
      }
   }

   private static void DrawCell(Grid grid, Vector2Int cellPosition, CellConfig cellConfig, int layer)
   {
      var pos = grid.CellToWorld(new Vector3Int(cellPosition.x, cellPosition.y, 0));
      var cellGo = Object.Instantiate(cellConfig.Prefab, grid.transform);
      cellGo.layer = layer;
      cellGo.transform.position = pos;
   }
}
