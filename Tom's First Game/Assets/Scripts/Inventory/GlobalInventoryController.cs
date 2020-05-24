using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventoryController : MonoBehaviour
{
    private static Dictionary<string, int> _inventory = new Dictionary<string, int>();

    public static void AddItems(string item, int amount)
    {
        IncrementDictionary(_inventory, item, amount);
        if (_inventory[item] < 1) 
        {
            _inventory.Remove(item);
        }
    }

    public static int ItemCount(string item)
    {
        if (!_inventory.ContainsKey(item)) return 0;
        else return _inventory[item];
    }

    private static void IncrementDictionary(Dictionary<string, int> dict, string key, int amount)
    {
        if (!dict.ContainsKey(key)) dict[key] = amount;
        else dict[key] += amount;
    }
}
