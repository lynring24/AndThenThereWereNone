using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Room1_TextBoxTrigger : MonoBehaviour
{
    public Text theText;

    public TextAsset textfile;

    private string[] textLines;

    bool isActive = true;
    bool isTyping = false;
    bool cancelTyping = false;
    bool once = true;

    float typingSpeed = 0.2f;

    private int currentLine;
    private int endAtLine;

    // Use this for initialization
   
    // Update is called once per frame
    void Update()
    {
        if (once)
        {
            isActive = true;
            initialize();
            once = false;
        }
        textLoad();
    }

    public void initialize() {

        if (theText != null)
        {
            textLines = new string[1];
            textLines = (textfile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            enableTextBox();
        }

        else if (!isActive)
        {
            disableTextBox();
        }
    }

    private IEnumerator textScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typingSpeed);
        }

        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void textLoad() {

        if (!isActive)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    currentLine = 0;
                    disableTextBox();
                }
                else
                {
                    StartCoroutine(textScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    public void enableTextBox()
    {
        isActive = true;
        theText.enabled = true;
        GameObject.Find("Canvas").transform.FindChild("DialogBox").gameObject.SetActive(true);

        GameObject.Find("MainDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("DoorDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("BedDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("TableDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("BigDrawerDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("BoxDialogBack").GetComponent<Collider>().enabled = true;

        GameObject.Find("DoorBack").GetComponent<Button>().enabled = false;
        GameObject.Find("KeypadBack").GetComponent<Button>().enabled = false;
        GameObject.Find("BedBack").GetComponent<Button>().enabled = false;
        GameObject.Find("BigDrawerBack").GetComponent<Button>().enabled = false;
        GameObject.Find("TableBack").GetComponent<Button>().enabled = false;
        GameObject.Find("BoxBack").GetComponent<Button>().enabled = false;

        GameObject.Find("CamLeft").GetComponent<Button>().enabled = false;
        GameObject.Find("CamRight").GetComponent<Button>().enabled = false;

        StartCoroutine(textScroll(textLines[currentLine]));
    }

    public void disableTextBox()
    {
        textLines = null;
        isActive = false;
        once = true;
        theText.enabled = false;

        //disable 시 대화창 비활성화
        GameObject.Find("DialogBox").gameObject.SetActive(false);

        //disable 시 dialog background collider 비활성화
        GameObject.Find("MainDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("DoorDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("BedDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("TableDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("BigDrawerDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("BoxDialogBack").GetComponent<Collider>().enabled = false;

        //아이템 획득 이미지 background 비활성화
        GameObject.Find("HammerWindowBack").gameObject.GetComponent<Image>().enabled = false;
        GameObject.Find("Paper1WindowBack").gameObject.GetComponent<Image>().enabled = false;
        GameObject.Find("Paper2WindowBack").gameObject.GetComponent<Image>().enabled = false;
        GameObject.Find("KeyWindowBack").gameObject.GetComponent<Image>().enabled = false;
        GameObject.Find("DiaryWindowBack").gameObject.GetComponent<Image>().enabled = false;

        //아이템 획득 이미지 비활성화
        GameObject.Find("HammerImage").gameObject.GetComponent<RawImage>().enabled = false;
        GameObject.Find("Paper1Image").gameObject.GetComponent<RawImage>().enabled = false;
        GameObject.Find("Paper2Image").gameObject.GetComponent<RawImage>().enabled = false;
        GameObject.Find("KeyImage").gameObject.GetComponent<RawImage>().enabled = false;
        GameObject.Find("DiaryImage").gameObject.GetComponent<RawImage>().enabled = false;

        GameObject.Find("DoorBack").GetComponent<Button>().enabled = true;
        GameObject.Find("KeypadBack").GetComponent<Button>().enabled = true;
        GameObject.Find("BedBack").GetComponent<Button>().enabled = true;
        GameObject.Find("BigDrawerBack").GetComponent<Button>().enabled = true;
        GameObject.Find("TableBack").GetComponent<Button>().enabled = true;
        GameObject.Find("BoxBack").GetComponent<Button>().enabled = true;
        GameObject.Find("CamLeft").GetComponent<Button>().enabled = true;
        GameObject.Find("CamRight").GetComponent<Button>().enabled = true;

        //해당 스크립트 비활성화
        GetComponent<Room1_TextBoxTrigger>().enabled = false;
    }
}