using UnityEngine;

public class DebugGridOutput : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private Camera _camera;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private GameObject _floorCellPrefab;
    [SerializeField] private GameObject _wallCellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var cellConfig in _levelConfig.Cells)
        {
            GameObject cellPrefab = null;
            if (cellConfig.CellConfigMin.CellType == CellType.Ground)
            {
                cellPrefab = _floorCellPrefab;
            }
            else if (cellConfig.CellConfigMin.CellType == CellType.Wall)
            {
                cellPrefab = _wallCellPrefab;
            }

            if (cellPrefab != null)
            {
                var cellPos = cellConfig.CellPosition;
                var pos = _grid.CellToWorld(new Vector3Int(cellPos.x, cellPos.y, 0));
                var cellGo = Instantiate(cellPrefab, transform);
                cellGo.transform.position = pos;
            }
        }
    }

    [ExecuteInEditMode]
    void Update()
    {
        var mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        var cell = _grid.WorldToCell(mouseWorldPoint);

        Debug.Log($"cell: {cell}, world: {mouseWorldPoint}");

    }
}
