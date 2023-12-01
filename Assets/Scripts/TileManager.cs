using TMPro;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public bool isMerged = false;
    private bool canMove = true;
    public TextMeshProUGUI scoreTextPrefab; // TextMeshProUGUI Prefab referans�

    private TextMeshProUGUI scoreText;
    private int currentValue = 2; // Ba�lang�� de�eri

    private void Awake()
    {
        // Script ilk y�klendi�inde TextMeshProUGUI bile�enini prefab referans�ndan olu�tur
        scoreText = Instantiate(scoreTextPrefab, transform);
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        TileManager otherTile = other.GetComponent<TileManager>();

        if (otherTile != null && !isMerged && !otherTile.isMerged)
        {
            // Di�er tile sadece fare ile ta��nan tile ise, sadece di�erini yok et
            if (otherTile.isDragged)
            {
                Destroy(otherTile.gameObject);
            }
            else
            {
                // De�erler ayn�ysa birle�tir
                if (CanMerge(otherTile))
                {
                    Merge(otherTile);
                }
                else
                {
                    canMove = false; // De�erler ayn� de�ilse, �st �ste koymay� engelle
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
        currentValue = newValue; // De�er g�ncelleme
        UpdateScoreText();

        Destroy(gameObject);
        otherTextMesh.text = newValue.ToString();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + currentValue;
    }


    // Fare ile ta��n�p ta��nmad���n� kontrol etmek i�in bir �zellik
    public bool isDragged = false;

    // Bu fonksiyon, fare ile ta��nd���nda �a�r�l�r
    public void SetDragged(bool dragged)
    {
        if (canMove && dragged) // Check if the tile can move and is being dragged
        {
            isDragged = dragged;
        }
    }

    // S�r�klenen prefab �zerine konulan prefab'in collider'�na �arpt���nda �al��an metod
    private void OnCollisionStay(Collision collision)
    {
        TileManager otherTile = collision.gameObject.GetComponent<TileManager>();

        if (otherTile != null && !CanMerge(otherTile))
        {
            canMove = false; // Birle�tirilemiyorsa i� i�e ge�melerini engelle
        }
        else
        {
            canMove = true; // �arp��ma yoksa veya birle�tirilebiliyorsa i� i�e ge�melerine izin ver
        }

        // S�r�klenen prefab kald�r�ld���nda ve birle�me engellendi�inde isDragged'i false yap
        if (!canMove && isDragged)
        {
            isDragged = false;
        }

        // �ki prefab birbirine de�iyorsa konumlar�n� ayarla
        if (collision.contacts.Length > 0)
        {
            // �ki prefab'�n birbirine de�di�i noktadan bir vekt�r al
            Vector3 contactPoint = collision.contacts[0].point;

            // �ki prefab'� birbirinden uzakla�t�r
            Vector3 offset = transform.position - otherTile.transform.position;
            transform.position = contactPoint + offset;
        }
    }


}
