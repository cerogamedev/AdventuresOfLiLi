using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }


    public TextAsset inkFile;
    public GameObject textBox;
    public GameObject customButton;
    public GameObject optionPanel;
    public bool isTalking = false;
    public GameObject bgPanel;

    public bool isWriting = false;

    static Story story;
    TextMeshProUGUI message;
    List<string> tags;
    static Choice choiceSelected;

    public float waitingTime;
    public bool finisDialogue = false;

    public TextMeshProUGUI _npcName;
    public Image _npcPortrait;

    public bool isInDialogue = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void NewStoryHere()
    {
        story = new Story(inkFile.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        optionPanel.SetActive(false);
        bgPanel.SetActive(false);

        message = textBox.transform.GetComponent<TextMeshProUGUI>();
        tags = new List<string>();
        choiceSelected = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isWriting == false && isInDialogue && story!= null)
        {
            if (story.canContinue)
            {
                AdvanceDialogue();
            }
            else if (optionPanel.transform.childCount != 0)
            {
                return;
            }
            else
                FinishDialogue();


        }
        if (Input.GetKeyDown(KeyCode.F) && isWriting == true)
        {
            finisDialogue = true;
        }
    }

    public void FinishDialogue()
    {
        isInDialogue = false;
        optionPanel.SetActive(false);
        bgPanel.SetActive(false);
        Debug.Log("End of Dialogue!");

    }

    public void AdvanceDialogue()
    {
        isWriting = true;
        string currentSentence = story.Continue();
        ParseTags();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        waitingTime = 0.05f;
        isWriting = true;
        WaitForSeconds wait = new WaitForSeconds(waitingTime);
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (letter.ToString() != "")
            {
                //SoundEffectManager.Instance.PlayButtonSound();
            }
            message.text += letter;
            if (finisDialogue == true)
            {
                textBox.GetComponent<TextMeshProUGUI>().text = sentence;
                isWriting = false;
                finisDialogue = false;
                break;
            }
            yield return wait;
        }
        isWriting = false;
        yield return null;
        //Are there any choices?
        if (story.currentChoices.Count != 0)
        {
            StartCoroutine(ShowChoices());
        }
    }

    // Create then show the choices on the screen until one got selected
    IEnumerator ShowChoices()
    {
        Debug.Log("There are choices need to be made here!");
        List<Choice> _choices = story.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate(customButton, optionPanel.transform);
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _choices[i].text;
            if (_choices[i].text != "")
            {
                temp.AddComponent<Selectable>();
                temp.GetComponent<Selectable>().element = _choices[i];
                temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
            }

        }

        optionPanel.SetActive(true);

        yield return new WaitUntil(() => { return choiceSelected != null; });
        AdvanceFromDecision();

    }

    // Tells the story which branch to go to
    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    // After a choice was made, turn off the panel and advance from that choice
    void AdvanceFromDecision()
    {
        optionPanel.SetActive(false);
        for (int i = 0; i < optionPanel.transform.childCount; i++)
        {
            Destroy(optionPanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        AdvanceDialogue();
    }

    /*** Tag Parser ***/
    /// In Inky, you can use tags which can be used to cue stuff in a game.
    /// This is just one way of doing it. Not the only method on how to trigger events. 
    void ParseTags()
    {
        tags = story.currentTags;
        foreach (string t in tags)
        {
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "color":
                    SetTextColor(param);
                    break;
                case "end":
                    SceneManager.LoadScene("StartScreen");
                    break;
            }
        }
    }



    void SetTextColor(string _color)
    {
        switch (_color)
        {
            case "red":
                message.color = Color.red;
                break;
            case "blue":
                message.color = Color.cyan;
                break;
            case "green":
                message.color = Color.green;
                break;
            case "white":
                message.color = Color.white;
                break;
            case "black":
                message.color = Color.black;
                break;
            default:
                Debug.Log($"{_color} is not available as a text color");
                break;
        }
    }
    public void StartTheDialogue()
    {
        optionPanel.SetActive(true);
        bgPanel.SetActive(true);
    }
}