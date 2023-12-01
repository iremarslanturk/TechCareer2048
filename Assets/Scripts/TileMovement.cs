using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float gridSize = 2.5f;
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    private bool isDragging = false;
    private Vector3 offset;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        TrySnapToGrid();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPos() + offset;

            // Check if the target position is empty before moving
            if (IsPositionEmpty(mousePos))
            {
                // Snap to grid and boundaries
                Vector3 snappedPos = new Vector3(
                    Mathf.Clamp(Mathf.Floor(mousePos.x / gridSize) * gridSize, minX, maxX),
                    transform.position.y,
                    Mathf.Clamp(Mathf.Floor(mousePos.z / gridSize) * gridSize, minZ, maxZ)
                );

                transform.position = snappedPos;
            }
        }
    }

    void TrySnapToGrid()
    {
        Vector3 currentPos = transform.position;

        // Check if the target position is empty before snapping
        if (IsPositionEmpty(currentPos))
        {
            // Snap to grid and boundaries
            Vector3 snappedPos = new Vector3(
                Mathf.Clamp(Mathf.Floor(currentPos.x / gridSize) * gridSize, minX, maxX),
                currentPos.y,
                Mathf.Clamp(Mathf.Floor(currentPos.z / gridSize) * gridSize, minZ, maxZ)
            );

            transform.position = snappedPos;
        }
    }

    bool IsPositionEmpty(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f); // Ayarladýðýnýz radyus deðeri

        // Eðer bu pozisyonda baþka bir obje yoksa, bu pozisyon boþtur
        return colliders.Length == 0;
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePoint = hit.point;
            mousePoint.y = transform.position.y; // Keep the same height as the tile
            return mousePoint;
        }

        // Default return if the ray doesn't hit anything
        return Vector3.zero;
    }
}
