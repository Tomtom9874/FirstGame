using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryItemText : MonoBehaviour
{
    [SerializeField]
    private string textType = "Default";
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string line)
    {
        text.text = line;
    }

    public string GetTextType()
    {
        return textType;
    }

}
