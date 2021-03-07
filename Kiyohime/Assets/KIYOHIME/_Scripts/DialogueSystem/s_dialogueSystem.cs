using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class s_dialogueSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public Queue<string> names;
    [SerializeField] private SpriteRenderer _spriteRend;
    [SerializeField] private TMP_Text _speakerName;
    [SerializeField] private TMP_Text _speakerText;

    GameObject player;

    int picNum = 0;

    s_dialogue d = null;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(s_dialogue dialogue)
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        sentences.Clear();
        names.Clear();
        d = null;

        picNum = 0;
        d = dialogue;
        _spriteRend.sprite = dialogue.charaPics[picNum];

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
        picNum++;
        _spriteRend.sprite = d.charaPics[picNum];
        if (sentences.Count == 0)
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

        player.GetComponent<Gamekit2D.PlayerCharacter>().inCinematic = false;
    }
}
