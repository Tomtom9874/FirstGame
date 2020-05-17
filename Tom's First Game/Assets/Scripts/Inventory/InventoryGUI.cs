using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItem slot;
    private Transform transform;
    private Vector3 offset;

    private void Start()
    {
        transform = GetComponent<Transform>();
        offset = new Vector3(0, 5, 0);
    }
    private void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space))
        {
            InventoryItem slotInstance;
            Debug.Log("SlotInstance");
            slotInstance = Instantiate(slot, transform.position + offset, Quaternion.identity, transform) as InventoryItem;
            offset += new Vector3(0, -1, 0);

        }
    }

}
