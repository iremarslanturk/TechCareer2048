using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public PrefabSlot[] slots; // Sahnedeki b�t�n b�lge noktalar�n� i�erir

    private void Start()
    {
        // Sahnedeki b�t�n PrefabSlot nesnelerini bul
        slots = FindObjectsOfType<PrefabSlot>();
    }

    // Bir b�lgeye prefab koyuldu�unda bu metot �a�r�l�r
    public void PlacePrefabInSlot(GameObject prefab, PrefabSlot slot)
    {
        slot.PlacePrefab(prefab);
    }

    // Bir b�lgeden prefab kald�r�ld���nda bu metot �a�r�l�r
    public void RemovePrefabFromSlot(PrefabSlot slot)
    {
        slot.RemovePrefab();
    }
}
