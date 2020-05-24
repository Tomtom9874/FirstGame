using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText = null;
    public Image _yesArrow;
    public Image _noArrow;
    public GameObject _dialogueCanvas;
    public GameObject _choiceCanvas;
    public int _characterDelay = 1;
    
    private Interactor _interactor;
    private Queue<string> _lines = new Queue<string>();
    private int _delay = 0;
    private bool _isSpeaking = false;
    private int _remainingCharacters;
    private bool _isActive = false;
    private string _choiceText;
    private bool _choiceLoaded = false;
    private bool _isChoosing = false;
    private bool _yesSelected = true;

    void Start()
    {
        _dialogueCanvas.SetActive(false);
        _noArrow.enabled = false;
        _interactor = FindObjectOfType<Interactor>();
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
            GlobalPlayerController.AddDecision(_choiceText, _yesSelected);
            EndDialogue();
        }
    }

    public void ChangeSelection()
    {
        if (_isChoosing)
        {
            _yesSelected = !_yesSelected;
            _yesArrow.enabled = _yesSelected;
            _noArrow.enabled = !_yesSelected;
        }
    }

    public void StartDialogue(string [] dialogue)
    {
        _isActive = true;
        _dialogueCanvas.SetActive(true);
        _choiceCanvas.SetActive(false);
        
        _lines.Clear();
        foreach(string sentence in dialogue)
        {
            _lines.Enqueue(sentence);
        }
        _interactor.StartConversation();
        if (_lines.Count == 0) DialogueEmpty();
        DisplayNextSentence();
    }

    public void StartDialogueWithChoice(string [] dialogue, string choiceText)
    {
        _choiceText = choiceText;
        _choiceLoaded = true;
        StartDialogue(dialogue);
    }
    
    private bool DisplayNextSentence()
    {
        if (_lines.Count == 0) return false;
        string sentence = _lines.Dequeue();
        _dialogueText.text = sentence;
        _dialogueText.maxVisibleCharacters = 0;
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
            _dialogueText.maxVisibleCharacters += _remainingCharacters;
            _remainingCharacters = 0;
            _isSpeaking = false;
        }
    }

    private void StartChoice()
    {
        _isChoosing = true;
        _choiceCanvas.SetActive(true);
        string sentence = _choiceText;
        _dialogueText.text = sentence;
        _dialogueText.maxVisibleCharacters = 0;
        _remainingCharacters = sentence.Length;
        _isSpeaking = false;
        _delay = _characterDelay;
    }

    private void AddChar()
    {
        _dialogueText.maxVisibleCharacters++;
        _remainingCharacters--;
        if (_remainingCharacters == 0) _isSpeaking = false;
        else _delay = _characterDelay;
    }

    private void EndDialogue()
    {
        _dialogueCanvas.SetActive(false);
        _isActive = false;
        _choiceLoaded = false;
        _isChoosing = false;
        _isSpeaking = false;
        _delay = 0;
        _remainingCharacters = 0;
        _choiceText = null;
        _yesSelected = true;
        _interactor.EndConversation();
    }

    private void DialogueEmpty()
    {
        if (_choiceLoaded) 
        {
            StartChoice();
        }
        else 
        {
            EndDialogue();
        }
    }
}
