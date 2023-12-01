using UnityEngine;

public class PrefabSlot : MonoBehaviour
{
    public bool isOccupied = false; // B�lgenin dolu olup olmad���n� kontrol eder
    public GameObject occupyingPrefab; // Bu b�lgeye yerle�tirilen prefab

    // Prefab koyuldu�unda bu b�lgeyi i�aretle
    public void PlacePrefab(GameObject prefab)
    {
        isOccupied = true;
        occupyingPrefab = prefab;
    }

    // Prefab kald�r�ld���nda bu b�lgeyi bo�alt
    public void RemovePrefab()
    {
        isOccupied = false;
        occupyingPrefab = null;
    }
}
