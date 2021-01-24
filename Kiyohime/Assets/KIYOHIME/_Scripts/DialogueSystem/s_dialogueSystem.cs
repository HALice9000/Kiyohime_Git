using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class s_dialogueSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public Queue<string> names;
    [SerializeField] private TMP_Text _speakerName;
    [SerializeField] private TMP_Text _speakerText;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(s_dialogue dialogue)
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        sentences.Clear();
        names.Clear();

        //_speakerName.text = dialogue.name[0];

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (var name in dialogue.names)
        {
            names.Enqueue(name);
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

        string name = names.Dequeue();
        _speakerName.text = name;
    }

    private void EndDialogue()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
