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

         var cellPos = cellConfig.CellPosition;
         var pos = grid.CellToWorld(new Vector3Int(cellPos.x, cellPos.y, 0));
         cellGo = Object.Instantiate(currentCellConfig.Prefab, grid.transform);
         cellGo.layer = layer;
         cellGo.transform.position = pos;
      }
   }
}
