using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxStart_5 : MonoBehaviour
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
		GameObject.Find ("shelfTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("gunTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("hammerTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("bedTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("lampTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("phoneTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("clothTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("postTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("clockTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;
		GameObject.Find ("keyTri").gameObject.GetComponent<TextBoxTrigger_5> ().enabled = false;

		// GameObject.Find("HammerWindowBack").gameObject.GetComponent<Image>().enabled = false;
		GameObject.Find("BackImage").gameObject.GetComponent<Image>().enabled = false;

		//아이템 획득 이미지 비활성화
		// GameObject.Find("HammerImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("keyImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("note4Image").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("postitImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("gunImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("hammerImage").gameObject.GetComponent<RawImage>().enabled = false;

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

		GameObject.Find("BackImage").GetComponent<Collider>().enabled = true;

		GameObject.Find("LightDialogBack").GetComponent<Collider>().enabled = true;
		GameObject.Find("ShelfDialogBack").GetComponent<Collider>().enabled = true;
		GameObject.Find("MirrorDialogBack").GetComponent<Collider>().enabled = true;
		GameObject.Find("HangerDialogBack").GetComponent<Collider>().enabled = true;
		//GameObject.Find("BoxDialogBack").GetComponent<Collider>().enabled = true;

		GameObject.Find ("CamLeft").GetComponent<Button> ().enabled = false;
		GameObject.Find ("CamRight").GetComponent<Button> ().enabled = false;
		StartCoroutine(textScroll(textLines[currentLine]));
    }

    public void disableTextBox()
    {
        currentLine = 0;
        theText.enabled = false;
		GameObject.Find("DialogBox").gameObject.SetActive(false);

		//disable 시 dialog background collider 비활성화
		GameObject.Find("MainDialogBack").GetComponent<Collider>().enabled = false;
		GameObject.Find("ShelfDialogBack").GetComponent<Collider>().enabled = false;
		GameObject.Find("LightDialogBack").GetComponent<Collider>().enabled = false;
		GameObject.Find("MirrorDialogBack").GetComponent<Collider>().enabled = false;
		GameObject.Find("HangerDialogBack").GetComponent<Collider>().enabled = false;

		GameObject.Find ("CamLeft").GetComponent<Button> ().enabled = true;
		GameObject.Find ("CamRight").GetComponent<Button> ().enabled = true;

        GetComponent<TextBoxStart_5>().enabled = false;

    }
}