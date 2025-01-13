using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TerminalManager : MonoBehaviour{
    public GameObject directoryLine;
    public GameObject responseLine;

    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;


    private void OnGUI() {
        if(terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            string userInput = terminalInput.text;

            ClearInputField();
            AddDirectoryLine(userInput);
            
            userInputLine.transform.SetAsLastSibling();

            //terminalInput.activateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField() {
        terminalInput.text = "";
    }
    
    void AddDirectoryLine(string userInput) {
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        GameObject msg = Instantiate(directoryLine, msgList.transform);
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);;

        msg.transform.GetChild(1).GetComponent<TMP_Text>().text = userInput;
    }
}