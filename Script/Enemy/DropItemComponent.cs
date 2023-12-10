using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemComponent : MonoBehaviour
{
    public List<GameObject> listItemPrefabs = new List<GameObject>(); // List prefab item yang bisa di-drop

    public void DropItem()
    {
        if (listItemPrefabs.Count > 0)
        {
            // Pilih secara acak prefab item dari list
            GameObject selectedItemPrefab = listItemPrefabs[UnityEngine.Random.Range(0, listItemPrefabs.Count)];

            // Instantiate item
            GameObject item = Instantiate(selectedItemPrefab, transform.position, Quaternion.identity);

            // Jika kamu ingin item sebagai child dari musuh, aktifkan baris berikut:
            // item.transform.parent = transform;
        }

        // Setelah selesai instantiate item, hancurkan musuh
        Destroy(gameObject);
    }
}
