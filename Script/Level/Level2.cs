using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public GameObject FinishPanel;
    public Transform level1;

    // Update is called once per frame
    void Update()
    {
        // Check the number of child objects
        int childCount = transform.childCount;
        int childCount1 = level1.childCount;

        if (childCount == 0 && childCount1 == 0)
        {
            FinishPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
