using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    // Need to have global controller set choice at begining of scene if decision has been made. 
    [SerializeField] private string _choiceDialogue = null;
    [SerializeField] private string _defaultChoice = null;
    [SerializeField] private string [] _choices = null;

    private string _currentChoice;
    private int _currentChoiceIndex;

    private void Start()
    {
        _currentChoice = _defaultChoice;
        _currentChoiceIndex = -1;
    }

    public void MakeChoice(int choice)
    {
        _currentChoiceIndex = choice;
        _currentChoice = _choices[choice];
    }

    public string GetCurrentChoice()
    {
        return _currentChoice;
    }

    public string [] GetAllChoices()
    {
        return _choices;
    }

    public string GetChoiceDialogue()
    {
        return _choiceDialogue;
    }

    public int GetCurrentChoiceIndex()
    {
        return _currentChoiceIndex;
    }
}
