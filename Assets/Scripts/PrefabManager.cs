using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public PrefabSlot[] slots; // Sahnedeki bütün bölge noktalarýný içerir

    private void Start()
    {
        // Sahnedeki bütün PrefabSlot nesnelerini bul
        slots = FindObjectsOfType<PrefabSlot>();
    }

    // Bir bölgeye prefab koyulduðunda bu metot çaðrýlýr
    public void PlacePrefabInSlot(GameObject prefab, PrefabSlot slot)
    {
        slot.PlacePrefab(prefab);
    }

    // Bir bölgeden prefab kaldýrýldýðýnda bu metot çaðrýlýr
    public void RemovePrefabFromSlot(PrefabSlot slot)
    {
        slot.RemovePrefab();
    }
}
