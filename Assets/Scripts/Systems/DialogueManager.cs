using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitImage;
    public Button continueButton;

    private Queue<string> dialogueQueue = new Queue<string>();
    private bool isDisplaying = false;

    private Dictionary<string, string[]> dialoguesRU = new Dictionary<string, string[]>()
    {
        {"prologue_intro", new string[] { "Артур: Тьма... везде только тьма...", "Где я? Что со мной?", "Этот лес... он проклят..." }},
        {"eileen_appears", new string[] { "Неизвестный голос: Артур!", "Это... это Эйлин?", "Я нашла тебя в лесу..." }},
        {"boss_taunt", new string[] { "Искажённый рыцарь: СМЕРТНЫЙ!", "Ты не достоин боротися со мной!", "Я ТЬМА ВОПЛОЩЁННАЯ!" }}
    };

    private Dictionary<string, string[]> dialoguesEN = new Dictionary<string, string[]>()
    {
        {"prologue_intro", new string[] { "Arthur: Darkness... everywhere...", "Where am I? What happened to me?", "This forest... it is cursed..." }},
        {"eileen_appears", new string[] { "Unknown voice: Arthur!", "Is that... Eileen?", "I found you in the forest..." }},
        {"boss_taunt", new string[] { "Twisted Knight: MORTAL!", "You are unworthy to face me!", "I AM DARKNESS INCARNATE!" }}
    };

    private bool useRussian = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dialoguePanel.SetActive(false);
        useRussian = LocalizationManager.Instance?.IsRussian ?? true;
    }

    public void StartDialogue(string dialogueKey)
    {
        Dictionary<string, string[]> currentDialogues = useRussian ? dialoguesRU : dialoguesEN;

        if (currentDialogues.ContainsKey(dialogueKey))
        {
            dialogueQueue.Clear();
            foreach (string line in currentDialogues[dialogueKey])
            {
                dialogueQueue.Enqueue(line);
            }

            dialoguePanel.SetActive(true);
            DisplayNextDialogue();
        }
    }

    private void DisplayNextDialogue()
    {
        if (dialogueQueue.Count > 0 && !isDisplaying)
        {
            string dialogue = dialogueQueue.Dequeue();
            StartCoroutine(TypeDialogue(dialogue));
        }
        else if (dialogueQueue.Count == 0)
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeDialogue(string text)
    {
        isDisplaying = true;
        dialogueText.text = "";

        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        isDisplaying = false;
        if (dialogueQueue.Count > 0)
        {
            continueButton.interactable = true;
        }
    }

    public void ContinueDialogue()
    {
        if (!isDisplaying && dialogueQueue.Count > 0)
        {
            DisplayNextDialogue();
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
