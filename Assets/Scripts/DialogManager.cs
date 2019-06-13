using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;
    public int currentline;

    // Start is called before the first frame update
    void Start() {

        dialogText.text = dialogLines[currentline];
    }

    // Update is called once per frame
    void Update() {
        if (dialogBox.activeInHierarchy) {
            if (Input.GetButtonUp("Fire1")) {
                currentline++;
                if (currentline == dialogLines.Length) {
                    dialogBox.SetActive(false);
                    currentline = 0;
                }
                else {
                    dialogText.text = dialogLines[currentline];
                }
            }
        }



    }
}
