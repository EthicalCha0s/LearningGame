using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {

    public Image fadeScreen;
    public float fadeSpeed = 1f;

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    // Start is called before the first frame update
    void Start() {

        if (shouldFadeToBlack) {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,1f);
        }
        if (shouldFadeFromBlack) {
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
