using UnityEngine;

namespace Src.Game.View
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Setup(Sprite sprite, CellViewOrder cellViewOrder)
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.sortingOrder = (int) cellViewOrder;
        }
    }
}
