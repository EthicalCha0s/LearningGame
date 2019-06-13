using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{

    public GameObject UIScreen;
    public GameObject player;
    // Start is called before the first frame update
    void Awake() {
        if (UIFade.instance == null) {
            Instantiate(UIScreen);
        }
        if (PlayerController.instance == null) {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
