using UnityEngine;

public class TileMergeHandler : MonoBehaviour
{
    private TileManager clickedTile;

    private void OnMouseDown()
    {
        clickedTile = null;
        TileManager[] tiles = FindObjectsOfType<TileManager>();

        foreach (TileManager tile in tiles)
        {
            if (tile.GetComponent<TileManager>().isDragged)
            {
                clickedTile = tile;
                break;
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        if (clickedTile != null)
        {
            Collider[] colliders = Physics.OverlapSphere(clickedTile.transform.position, 0.1f);
            foreach (Collider collider in colliders)
            {
                TileManager otherTile = collider.GetComponent<TileManager>();
                if (otherTile != null && otherTile != clickedTile && !otherTile.isMerged)
                {
                    // Merge with the overlapping tile
                    clickedTile.Merge(otherTile);
                    break;
                }
            }

            // Reset the dragged state
            clickedTile.SetDragged(false);
        }
    }
}
