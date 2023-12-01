using TMPro;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public bool isMerged = false;
    private bool canMove = true;
    public TextMeshProUGUI scoreTextPrefab; // TextMeshProUGUI Prefab referansý

    private TextMeshProUGUI scoreText;
    private int currentValue = 2; // Baþlangýç deðeri

    private void Awake()
    {
        // Script ilk yüklendiðinde TextMeshProUGUI bileþenini prefab referansýndan oluþtur
        scoreText = Instantiate(scoreTextPrefab, transform);
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        TileManager otherTile = other.GetComponent<TileManager>();

        if (otherTile != null && !isMerged && !otherTile.isMerged)
        {
            // Diðer tile sadece fare ile taþýnan tile ise, sadece diðerini yok et
            if (otherTile.isDragged)
            {
                Destroy(otherTile.gameObject);
            }
            else
            {
                // Deðerler aynýysa birleþtir
                if (CanMerge(otherTile))
                {
                    Merge(otherTile);
                }
                else
                {
                    canMove = false; // Deðerler ayný deðilse, üst üste koymayý engelle
                }
            }
        }
    }

    public bool CanMerge(TileManager otherTile)
    {
        TextMeshProUGUI thisTextMesh = GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI otherTextMesh = otherTile.GetComponentInChildren<TextMeshProUGUI>();

        return thisTextMesh.text == otherTextMesh.text;
    }

    public void Merge(TileManager otherTile)
    {
        isMerged = true;
        canMove = false;

        TextMeshProUGUI otherTextMesh = otherTile.GetComponentInChildren<TextMeshProUGUI>();
        int newValue = int.Parse(otherTextMesh.text) * 2;
        currentValue = newValue; // Deðer güncelleme
        UpdateScoreText();

        Destroy(gameObject);
        otherTextMesh.text = newValue.ToString();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + currentValue;
    }


    // Fare ile taþýnýp taþýnmadýðýný kontrol etmek için bir özellik
    public bool isDragged = false;

    // Bu fonksiyon, fare ile taþýndýðýnda çaðrýlýr
    public void SetDragged(bool dragged)
    {
        if (canMove && dragged) // Check if the tile can move and is being dragged
        {
            isDragged = dragged;
        }
    }

    // Sürüklenen prefab üzerine konulan prefab'in collider'ýna çarptýðýnda çalýþan metod
    private void OnCollisionStay(Collision collision)
    {
        TileManager otherTile = collision.gameObject.GetComponent<TileManager>();

        if (otherTile != null && !CanMerge(otherTile))
        {
            canMove = false; // Birleþtirilemiyorsa iç içe geçmelerini engelle
        }
        else
        {
            canMove = true; // Çarpýþma yoksa veya birleþtirilebiliyorsa iç içe geçmelerine izin ver
        }

        // Sürüklenen prefab kaldýrýldýðýnda ve birleþme engellendiðinde isDragged'i false yap
        if (!canMove && isDragged)
        {
            isDragged = false;
        }

        // Ýki prefab birbirine deðiyorsa konumlarýný ayarla
        if (collision.contacts.Length > 0)
        {
            // Ýki prefab'ýn birbirine deðdiði noktadan bir vektör al
            Vector3 contactPoint = collision.contacts[0].point;

            // Ýki prefab'ý birbirinden uzaklaþtýr
            Vector3 offset = transform.position - otherTile.transform.position;
            transform.position = contactPoint + offset;
        }
    }


}
