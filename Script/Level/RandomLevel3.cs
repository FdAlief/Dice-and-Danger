using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel3 : MonoBehaviour
{
    // Posisi tempat objek akan muncul
    public Vector3 spawnPosition;
    private ListManager listManager;

    private void Start()
    {
        // Cari objek dengan skrip ListManager di seluruh hierarki
        listManager = FindObjectOfType<ListManager>();
    }

    // Ketika objek lain memasuki zona trigger
    private void OnTriggerEnter(Collider other)
    {
        // Pastikan objek yang masuk adalah objek yang diinginkan dan ListManager tidak null
        if (other.CompareTag("Player") && listManager != null && listManager.objToSpawnList.Count > 0)
        {
            // Pilih secara acak indeks dari list objek
            int randomIndex = Random.Range(0, listManager.objToSpawnList.Count);

            // Munculkan objek pada posisi yang diinginkan
            Instantiate(listManager.objToSpawnList[randomIndex], spawnPosition, Quaternion.identity);

            // Hapus objek dari list agar tidak muncul lagi
            listManager.objToSpawnList.RemoveAt(randomIndex);
            Destroy(gameObject);
        }
    }
}
