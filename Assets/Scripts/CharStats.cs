using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentExp;

    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseExp = 1000;
    public int[] mpLvlBonus;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int strength;
    public int defence;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start() {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;

        for (int i = 2; i < expToNextLevel.Length; i++) {
            Debug.Log(i);
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            addExp(500);
        }
    }

    public void addExp(int expToAdd) {
        currentExp += expToAdd;

        if (playerLevel < maxLevel && currentExp >= expToNextLevel[playerLevel]) {
            currentExp -= expToNextLevel[playerLevel];
            playerLevel++;

            //determine whether to add to strength or defence based on odd or even
            if (playerLevel % 2 == 0) {
                strength++;
            }
            else {
                defence++;
            }
            maxHP = Mathf.FloorToInt(maxHP * 1.05f);
            currentHP = maxHP;

            maxMP += mpLvlBonus[playerLevel];
            currentMP = maxMP;
        }

        if (playerLevel >= maxLevel) {
            currentExp = 0;
        }
    }
}
