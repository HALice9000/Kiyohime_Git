using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class s_dialogueSystem : MonoBehaviour
{
    public Queue<string> sentences;
    [SerializeField] private TMP_Text _speakerName;
    [SerializeField] private TMP_Text _speakerText;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(s_dialogue dialogue)
    {
        sentences.Clear();

        _speakerName.text = dialogue.name;

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        _speakerText.text = sentence;
    }

    private void EndDialogue()
    {

    }
}
