using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    
    [SerializeField] private int _characterDelay = 1;
    
    private DialogueGui _gui;
    private Interactor _interactor;
    private Queue<string> _lines = new Queue<string>();
    private int _delay = 0;
    private bool _isSpeaking = false;
    private int _remainingCharacters;
    private bool _isActive = false;
    private string _choiceText;
    private bool _isChoosing = false;
    private int _currentSelection;
    private Choice _choice;
    private string [] _allChoices = null;

    void Start()
    {
        _interactor = FindObjectOfType<Interactor>();
        _gui = GetComponent<DialogueGui>();
    }

    void Update()
    {
        {
            AddChar();
        }
        if (_delay > 0) 
        {
            _delay--;
        }
    }
    
    public void ReceiveSelection()
    {
        if (_isActive && !_isChoosing) 
        {
            advanceDialogue();
        }
        if (_isChoosing && _remainingCharacters < 1) 
        {
            _choice.MakeChoice(_currentSelection);
            GlobalPlayerController.AddDecision(_choice);
            EndDialogue();
        }
    }

    public void ChangeSelection(string direction)
    {
        if (_isChoosing)
        {
            if (direction == "Down")
            {
                _currentSelection++;
                if (_currentSelection >= _allChoices.Length)
                {
                    _currentSelection = 0;
                }
            }
            if (direction == "Up")
            {
                _currentSelection--;
                if (_currentSelection < 0)
                {
                    _currentSelection = _allChoices.Length - 1;
                }
            }
            _gui.SwitchArrow(_currentSelection);
        }
    }

    public void StartDialogue(string [] dialogue)
    {
        _gui.StartDialogue();
        _isActive = true;
        _lines.Clear();
        foreach(string sentence in dialogue)
        {
            _lines.Enqueue(sentence);
        }
        _interactor.StartConversation();
        if (_lines.Count == 0) 
        {
            DialogueEmpty();
        }
        DisplayNextSentence();
    }

    public void StartDialogueWithChoice(string [] dialogue, Choice choice)
    {
        _allChoices = choice.GetAllChoices();
        _choiceText = choice.GetChoiceDialogue();
        _choice = choice;
        StartDialogue(dialogue);
    }
    
    private bool DisplayNextSentence()
    {
        if (_lines.Count == 0) 
        {
            return false;
        }
        string sentence = _lines.Dequeue();
        _gui.StartNewSentence(sentence);
        _remainingCharacters = sentence.Length;
        _isSpeaking = true;
        _delay = _characterDelay;
        return true;
    }

    private void advanceDialogue()
    {
        if (!_isSpeaking)
        {
            if (!DisplayNextSentence()) 
            {
                DialogueEmpty();
            }
        }
        else
        {
            _gui.IncreaseVisibleCharacters(_remainingCharacters);
            _remainingCharacters = 0;
            _isSpeaking = false;
        }
    }

    private void StartChoice()
    {
        _currentSelection = 0;
        _isChoosing = true;
        string sentence = _choiceText;
        _gui.StartChoice(_choice);
        _remainingCharacters = sentence.Length;
        _isSpeaking = false;
        _delay = _characterDelay;
    }

    private void AddChar()
    {
        _gui.IncreaseVisibleCharacters(1);
        _remainingCharacters--;
        if (_remainingCharacters == 0) 
        {
            _isSpeaking = false;
        }
        else 
        {
            _delay = _characterDelay;
        }
    }

    private void EndDialogue()
    {
        _isActive = false;
        _choice = null;
        _isChoosing = false;
        _isSpeaking = false;
        _gui.EndDialogue();
        _interactor.EndConversation();
    }

    private void DialogueEmpty()
    {
        if (_choice != null) 
        {
            StartChoice();
        }
        else 
        {
            EndDialogue();
        }
    }
}
