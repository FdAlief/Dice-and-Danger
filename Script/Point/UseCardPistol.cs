using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardPistol : MonoBehaviour
{
    public int hargaCard;
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void onClickButton()
    {
        if (PointManager.totalPoint >= hargaCard)
        {
            PointManager.totalPoint -= hargaCard;
            player.Pistol();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Uang nya gk ada mank");
        }
    }
}
