using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueGui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText = null;
    [SerializeField] private GameObject _selectionArrow = null;

    [SerializeField] private GameObject _choices = null;
    private bool _initialOff = true;

    private void Start()
    {

    }
    private void Update()
    {
        if (_initialOff)
        {
            gameObject.SetActive(false);
            _initialOff = false;
        }
    }

    public void IncreaseVisibleCharacters(int count)
    {
        _dialogueText.maxVisibleCharacters += count;
    }

    public void StartNewSentence(string line)
    {
        _dialogueText.maxVisibleCharacters = 0;
        _dialogueText.text = line;
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);
        _choices.SetActive(false);
    }

    public void StartChoice(Choice choice)
    {
        _choices.SetActive(true);
        StartNewSentence(choice.GetChoiceDialogue());
    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
    }

    public void SwitchArrow(int selection)
    {
        Vector2 pos = _selectionArrow.GetComponent<RectTransform>().position;
    }
}
