using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCradSpeed : MonoBehaviour
{
    public int hargaCard = 3;
    public int bonusSpeed = 3;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void onClickButton()
    {
        if (PointManager.totalPoint >= hargaCard)
        {
            PointManager.totalPoint -= hargaCard;
            playerController.movementSpeed += bonusSpeed;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Uang nya gk ada mank");
        }
    }
}
