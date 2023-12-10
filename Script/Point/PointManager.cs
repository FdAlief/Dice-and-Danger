using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int StartingPoint = 0;
    public static int totalPoint = 0;
    public TextMeshProUGUI goldText; // Komponen TMP_Text untuk menampilkan jumlah gold

    // Start is called before the first frame update
    void Start()
    {
        PointManager.totalPoint = StartingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = totalPoint.ToString();
    }
}
