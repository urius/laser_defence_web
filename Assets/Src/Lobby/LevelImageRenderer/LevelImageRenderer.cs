using UnityEngine;

public class LevelImageRenderer : MonoBehaviour
{
    [SerializeField] private Camera _renderCamera;
    [SerializeField] private Grid _grid;

    public void RenderLevel(LevelConfig levelConfig, CellConfigProvider cellConfigProvider)
    {
        Clear();

        _renderCamera.enabled = true;
        _grid.DrawLevel(levelConfig, cellConfigProvider);
        _renderCamera.Render();
        _renderCamera.enabled = false;
        
        Clear();
    }

    private void Clear()
    {
        for (var i = _grid.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(_grid.transform.GetChild(i).gameObject);
        }
    }
}
