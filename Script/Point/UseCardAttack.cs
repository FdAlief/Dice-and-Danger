using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardAttack : MonoBehaviour
{
    public int hargaCard;
    public int bonusdamage = 10;

    private PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    public void onClickButton()
    {
        if (PointManager.totalPoint >= hargaCard)
        {
            PointManager.totalPoint -= hargaCard;
            playerAttack.damage += bonusdamage;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Uang nya gk ada mank");
        }
    }
}
