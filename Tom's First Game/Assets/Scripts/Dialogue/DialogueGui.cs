using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueGui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText = null;
    [SerializeField] private TextMeshProUGUI _choiceText = null;
    [SerializeField] private GameObject _selectionArrow = null;
    [SerializeField] private GameObject _choices = null;

    private bool _initialOff = true;
    private float offset = 23;

    private RectTransform _selectionTransform;
    private Vector3 _initialSelectionPosition;

    private void Start()
    {
        _selectionTransform = _selectionArrow.GetComponent<RectTransform>();
        _initialSelectionPosition = _selectionTransform.localPosition;
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
        _choiceText.maxVisibleCharacters += count;
    }

    public void StartNewSentence(string line)
    {
        _dialogueText.maxVisibleCharacters = 0;
        _dialogueText.text = line;
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);
        _dialogueText.enabled = true;
        _choices.SetActive(false);
    }

    public void StartChoice(Choice choice)
    {
        _choices.SetActive(true);
        _dialogueText.enabled = false;
        _choiceText.text = choice.GetChoiceDialogue();
        StartNewSentence(choice.GetChoiceDialogue());
    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
    }

    public void SwitchArrow(int selection)
    {
        Debug.Log(selection);
        Debug.Log(_initialSelectionPosition);
        _selectionTransform.localPosition = _initialSelectionPosition + (offset * selection * Vector3.down);
        Debug.Log(_selectionTransform.localPosition);
    }
}
