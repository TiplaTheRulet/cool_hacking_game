using TMPro;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text output;

    public GameObject inbox;
    public void LoginingFunc()
    {
        if (emailInput.text != "johnkler@fn.jk")
        {
            output.SetText(emailInput.text + " is not found. Please check if you entered your e'mail correcrly.");
            return;
        }

        if (passwordInput.text != "8AdH")
        {
            output.SetText("Wrong password. Try again");
            return;
        }

        inbox.SetActive(true);
    }
}
