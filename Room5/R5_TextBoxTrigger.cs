using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxTrigger_5: MonoBehaviour
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

		GameObject.Find("BackImage").GetComponent<Collider>().enabled = true;

        GameObject.Find("LightDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("ShelfDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("MirrorDialogBack").GetComponent<Collider>().enabled = true;
        GameObject.Find("HangerDialogBack").GetComponent<Collider>().enabled = true;
        //GameObject.Find("BoxDialogBack").GetComponent<Collider>().enabled = true;

		GameObject.Find ("LightBack").GetComponent<Button> ().enabled = false;
		GameObject.Find ("MirrorBack").GetComponent<Button> ().enabled = false;
		GameObject.Find ("HangerBack").GetComponent<Button> ().enabled = false;
		GameObject.Find ("ShelfBack").GetComponent<Button> ().enabled = false;
		GameObject.Find ("CamLeft").GetComponent<Button> ().enabled = false;
		GameObject.Find ("CamRight").GetComponent<Button> ().enabled = false;

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
        GameObject.Find("ShelfDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("LightDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("MirrorDialogBack").GetComponent<Collider>().enabled = false;
        GameObject.Find("HangerDialogBack").GetComponent<Collider>().enabled = false;


        //아이템 획득 이미지 background 비활성화
       // GameObject.Find("HammerWindowBack").gameObject.GetComponent<Image>().enabled = false;
		GameObject.Find("BackImage").gameObject.GetComponent<Image>().enabled = false;

        //아이템 획득 이미지 비활성화
       // GameObject.Find("HammerImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("keyImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("note4Image").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("postitImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("gunImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find("hammerImage").gameObject.GetComponent<RawImage>().enabled = false;
		GameObject.Find ("LightBack").GetComponent<Button> ().enabled = true;
		GameObject.Find ("MirrorBack").GetComponent<Button> ().enabled = true;
		GameObject.Find ("HangerBack").GetComponent<Button> ().enabled = true;
		GameObject.Find ("ShelfBack").GetComponent<Button> ().enabled = true;

		GameObject.Find ("CamLeft").GetComponent<Button> ().enabled = true;
		GameObject.Find ("CamRight").GetComponent<Button> ().enabled = true;
        //해당 스크립트 비활성화
        GetComponent<TextBoxTrigger_5>().enabled = false;
    }
}