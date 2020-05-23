﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalPlayerController
{
    // Stores any data that needs to persist between scenes!
    private static Dictionary<string, Vector2> _positions = new Dictionary<string, Vector2>();

    private static Dictionary<string, bool> _decisions = new Dictionary<string, bool>();
    private static Dictionary<Vector2, bool> _destroyedObjects = new Dictionary<Vector2, bool>();

    public static void ReDestroyObjects()
    {
        OnDestroy[] components = GameObject.FindObjectsOfType<OnDestroy>();
        foreach(OnDestroy comp in components){
            if (_destroyedObjects.ContainsKey(comp.Position)) comp.SelfDestruct();
        }
    }

    // Getters
    public static Vector2 GetPosition(string scene) {return _positions[scene];}

    public static int CheckDecision(string decision) 
    {
        if (!_decisions.ContainsKey(decision)) return -1;
        if (_decisions[decision]) return 1;
        else return 0;
    }

    // Setters
    public static void SetPosition(string scene, Vector2 position)
    {
        _positions[scene] = position;
    }

    public static void SetDestroy(Vector2 location, bool destroyed)
    {
        _destroyedObjects[location] = true;
    }

    public static void AddDecision(string question, bool decision)
    {
        _decisions[question] = decision;
    }

    public static bool CheckPositionsKey(string key)
    {
        return _positions.ContainsKey(key);
    }

    public static void PrintDecisions()
    {
        if (_decisions.Count == 0) Debug.Log("No Decisions!");
        foreach ( KeyValuePair<string, bool> decisions in _decisions)
        {
            Debug.Log(decisions);
        }
    }

    private static void IncrementDictionary(Dictionary<string, int> dict, string key, int amount)
    {
        if (!dict.ContainsKey(key)) dict[key] = amount;
        else dict[key] += amount;
    }
}
