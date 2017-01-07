using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Room1_TextBoxStart : MonoBehaviour
{
    public Text theText;

    public TextAsset textfile;

    public string[] textLines;

    bool isActive = true;
    bool isTyping = false;
    bool cancelTyping = false;

    float typingSpeed=0.2f;

    public int currentLine;
    public int endAtLine;

    // Use this for initialization
    void Start()
    {
        //시작 트리거를 제외한 각 트리거에 해당하는 스크립트 비활성화
        GameObject.Find("SwitchDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("DoorDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("ExitDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("BedDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("DrawerDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("TableDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("HammerDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("WindowDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("DiaryDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("BoxDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("PaperDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("KeyDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;
        GameObject.Find("BrokenHammerDialogTri").gameObject.GetComponent<Room1_TextBoxTrigger>().enabled = false;

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

        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        textLoad();
    }

    public void initialize() {       

        if (textfile != null)
        {
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
        GameObject.Find("Canvas").transform.FindChild("DialogBox").gameObject.SetActive(true);

        GameObject.Find("MainDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("DoorDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("BedDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("TableDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("BigDrawerDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("BoxDialogBack").GetComponent<Collider>().enabled = true;

        StartCoroutine(textScroll(textLines[currentLine]));
    }

    public void disableTextBox()
    {
        currentLine = 0;
        theText.enabled = false;
        GameObject.Find("DialogBox").gameObject.SetActive(false);
        GameObject.Find("MainDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("DoorDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("BedDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("TableDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("BigDrawerDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("BoxDialogBack").GetComponent<Collider>().enabled = false;

        GetComponent<Room1_TextBoxStart>().enabled = false;

    }
}