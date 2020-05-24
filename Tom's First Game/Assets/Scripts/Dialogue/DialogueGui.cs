using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueGui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText = null;
    [SerializeField] private Image _yesArrow = null;
    [SerializeField] private Image _noArrow = null;

    private GameObject _choiceCanvas;
    private bool _initialOff = true;

    private void Start()
    {
        _noArrow.enabled = false;
        Canvas [] canvasChildren = GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in canvasChildren)
        {
            _choiceCanvas = canvas.gameObject;
        }
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
        _choiceCanvas.SetActive(false);
    }

    public void StartChoice(string line)
    {
        _choiceCanvas.SetActive(true);
        StartNewSentence(line);
    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
    }

    public void SwitchArrow(bool selection)
    {
        _yesArrow.enabled = selection;
        _noArrow.enabled = !selection;
    }
}
