using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {

    public static UIFade instance;
    public Image fadeScreen;
    public float fadeSpeed = .5f;

    public bool shouldFadeToBlack;
    public bool ShouldFadeFromBlack;

    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (shouldFadeToBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f) { //check to end fade
                shouldFadeToBlack = false;
            }
        }
        if (ShouldFadeFromBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, -1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a < 0.001f) { //check to end fade (weird bug when use 0f)
                ShouldFadeFromBlack = false;
            }
        }
    }

    public void fadeToBlack() {
        this.shouldFadeToBlack = true;
        this.ShouldFadeFromBlack = false;
    }
    public void fadeFromBlack() {
        this.ShouldFadeFromBlack = true;
        this.shouldFadeToBlack = false;
    }
}
