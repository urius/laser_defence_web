using UnityEngine;

public class DebugGridOutput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private Grid _grid;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private CellConfigProvider _cellConfigProvider;
    

    // Start is called before the first frame update
    void Start()
    {
        _grid.DrawLevel(_levelConfig, _cellConfigProvider);
    }

    [ExecuteInEditMode]
    void Update()
    {
        var mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        var cell = _grid.WorldToCell(mouseWorldPoint);

        Debug.Log($"cell: {cell}, world: {mouseWorldPoint}");

    }
}
