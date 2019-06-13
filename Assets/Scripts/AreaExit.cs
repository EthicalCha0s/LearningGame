using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;
    public BoxCollider2D trigger;
    public string areaTransitionName;

    public AreaEntrance theEntrance;

    // Use this for initialization
    void Start() {
        theEntrance.transitionName = this.areaTransitionName;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            UIFade.instance.fadeToBlack();
            SceneManager.LoadScene(areaToLoad);
            PlayerController.instance.areaTransitionName = this.areaTransitionName;
        }
    }
}
