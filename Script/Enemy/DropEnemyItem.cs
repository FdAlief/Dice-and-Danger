using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEnemyItem : MonoBehaviour
{
    public List<GameObject> listItemPrefabs = new List<GameObject>(); // List prefab item yang bisa di-drop

    void Start()
    {
        // Tambahkan komponen DropItem pada musuh
        DropItemComponent dropItemComponent = gameObject.AddComponent<DropItemComponent>();
        dropItemComponent.listItemPrefabs = listItemPrefabs;
    }
}
