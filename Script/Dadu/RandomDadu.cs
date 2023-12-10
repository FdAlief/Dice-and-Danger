using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDadu : MonoBehaviour
{
    public Image[] diceImages;
    public float activationDuration = 8f;
    public float animDuration = 3f;
    public Button acakDaduButton;
    public Animator animDadu;
    public GameObject panelAnimasi;

    public GameObject Angka1;
    public GameObject Angka2;
    public GameObject Angka3;
    public GameObject Angka4;
    public GameObject Angka5;
    public GameObject Angka6;

    public void OnButtonClick()
    {
        panelAnimasi.SetActive(true);
        if (animDadu != null)
        {
            animDadu.SetTrigger("Play");
        }

        StartCoroutine(animDurationButton());
        
    }

    private IEnumerator animDurationButton()
    {
        yield return new WaitForSeconds(animDuration);
        panelAnimasi.SetActive(false);
        if (animDadu != null)
        {
            animDadu.ResetTrigger("Play");
        }
        StartCoroutine(ActivateRandomImage());
    }

    private IEnumerator ActivateRandomImage()
    {
        // Menonaktifkan tombol saat tombol diklik
        acakDaduButton.interactable = false;

        // Menonaktifkan semua gambar dadu
        foreach (Image diceImage in diceImages)
        {
            diceImage.gameObject.SetActive(false);
        }

        // Mengaktifkan gambar dadu secara acak
        int randomIndex = Random.Range(0, diceImages.Length);
        diceImages[randomIndex].gameObject.SetActive(true);

        dadu();

        // Mengaktifkan kembali tombol setelah menunggu
        yield return new WaitForSeconds(activationDuration);
        acakDaduButton.interactable = true;
    }

    public void dadu()
    {
        if (Angka1.activeInHierarchy)
        {
            PointManager.totalPoint += 1;
        }

        if (Angka2.activeInHierarchy)
        {
            PointManager.totalPoint += 2;
        }

        if (Angka3.activeInHierarchy)
        {
            PointManager.totalPoint += 3;
        }

        if (Angka4.activeInHierarchy)
        {
            PointManager.totalPoint += 4;
        }

        if (Angka5.activeInHierarchy)
        {
            PointManager.totalPoint += 5;
        }

        if (Angka6.activeInHierarchy)
        {
            PointManager.totalPoint += 6;
        }
    }
}
