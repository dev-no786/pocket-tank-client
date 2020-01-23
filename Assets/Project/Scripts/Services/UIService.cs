using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    public InputField uiInput = null;
	public Button uiSend = null;
	public Text uiChatLog = null;

    // Start is called before the first frame update
    void Start()
    {
        

        uiSend.onClick.AddListener(() => {
			// SendChat(uiInput.text);
			uiInput.text = "";
			uiInput.ActivateInputField();
		});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
