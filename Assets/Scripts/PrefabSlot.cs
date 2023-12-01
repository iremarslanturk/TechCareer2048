using UnityEngine;

public class PrefabSlot : MonoBehaviour
{
    public bool isOccupied = false; // Bölgenin dolu olup olmadýðýný kontrol eder
    public GameObject occupyingPrefab; // Bu bölgeye yerleþtirilen prefab

    // Prefab koyulduðunda bu bölgeyi iþaretle
    public void PlacePrefab(GameObject prefab)
    {
        isOccupied = true;
        occupyingPrefab = prefab;
    }

    // Prefab kaldýrýldýðýnda bu bölgeyi boþalt
    public void RemovePrefab()
    {
        isOccupied = false;
        occupyingPrefab = null;
    }
}
