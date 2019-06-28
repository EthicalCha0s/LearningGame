using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;
    private CharStats[] playerStats;

    public Text[] nameText, hpText, mpText, lvlText, expText;
    public Slider[] expSlider;
    public Image[] characterImage;
    public GameObject[] charStatHolder;

    public Text nameTextSingle, hpTextSingle, expTextSingle, mpTextSingle, lvlTextSingle;
    public Slider expSliderSingle, hpSliderSingle, mpSliderSingle;
    public Image characterImageSingle;
    public GameObject charStatHolderSingle;

    private int activePlayerCount, activePlayerPos;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            if (theMenu.activeInHierarchy) {
                theMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            }
            else {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;

                //Updating the text in the menu

            }
        }

        //test 
        if (theMenu.activeInHierarchy) {
            UpdateMainStats();
        }
    }

    public void UpdateMainStats() {
        playerStats = GameManager.instance.playerStats;

        activePlayerCount = 0;

        for (int i = 0; i < playerStats.Length; i++) {
            if (playerStats[i].gameObject.activeInHierarchy) {
                activePlayerCount++;
                activePlayerPos = i;
            }
            else {
                charStatHolder[i].SetActive(false);
            }
        }

        if (activePlayerCount > 1) {
            charStatHolderSingle.SetActive(false);
            for (int i = 0; i < playerStats.Length; i++) {
                if (playerStats[i].gameObject.activeInHierarchy) {                    
                    //Show the active player in the menu
                    charStatHolder[i].SetActive(true);

                    //Update their stats in the menu
                    nameText[i].text = playerStats[i].charName;
                    hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                    mpText[i].text = "MP: " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                    lvlText[i].text = "Lvl: " + playerStats[i].playerLevel;
                    expText[i].text = "" + playerStats[i].currentExp + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                    expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                    expSlider[i].value = playerStats[i].currentExp;
                    characterImage[i].sprite = playerStats[i].charImage;
                }
            }
        }
        else if (activePlayerCount == 1) {
            charStatHolder[activePlayerPos].SetActive(false);
            charStatHolderSingle.SetActive(true);

            nameTextSingle.text = playerStats[activePlayerPos].charName;
            hpTextSingle.text = "" + playerStats[activePlayerPos].currentHP + "/" + playerStats[activePlayerPos].maxHP;
            mpTextSingle.text = "" + playerStats[activePlayerPos].currentMP + "/" + playerStats[activePlayerPos].maxMP;
            lvlTextSingle.text = "Lvl: " + playerStats[activePlayerPos].playerLevel;
            expTextSingle.text = "" + playerStats[activePlayerPos].currentExp + "/" + playerStats[activePlayerPos].expToNextLevel[playerStats[activePlayerPos].playerLevel];

            expSliderSingle.maxValue = playerStats[activePlayerPos].expToNextLevel[playerStats[activePlayerPos].playerLevel];
            expSliderSingle.value = playerStats[activePlayerPos].currentExp;

            hpSliderSingle.maxValue = playerStats[activePlayerPos].maxHP;
            hpSliderSingle.value = playerStats[activePlayerPos].currentHP;

            mpSliderSingle.maxValue = playerStats[activePlayerPos].maxMP;
            mpSliderSingle.value = playerStats[activePlayerPos].currentMP;

            characterImageSingle.sprite = playerStats[activePlayerPos].charImage;
        }
    }
}
