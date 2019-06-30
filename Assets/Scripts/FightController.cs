using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    int chances;
    GameObject enemy;
    public GameObject slime;
    public GameObject character;
    public bool playerTurn;
    bool preventive;
    bool defending;
    int damage;
    EnemyBehaviour eb;
    PlayerController pc;
    public Image healthBarPlayer;
    public Image healthBarEnemy;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI enemyHealth;

    public Text logText1;
    public Text logText2;
    public Text logText3;
    public Text logText4;

    public Button actionButton1;
    public Button actionButton2;
    public Button actionButton3;
    public Button actionButton4;





    // Start is called before the first frame update
    void Start()
    {

        healthBarEnemy.fillAmount = 1;
        preventive = false;
        defending = false;
        

        enemy = getMonsterFromPool(SceneManager.GetActiveScene().name);

        eb = enemy.GetComponent<EnemyBehaviour>();
        pc = character.GetComponent<PlayerController>();

        playerHealth.text = pc.actualLife + " / " + pc.life;
        healthBarPlayer.fillAmount = (float)((pc.actualLife * 100) / pc.life) / 100;

        logText1.text = "A wild " + eb.monsterName + " appeared.";
        logText2.text = " ";
        logText3.text = " ";
        logText4.text = " ";

        enemyHealth.text = eb.remainingLife + " / " + eb.life;
        playerHealth.text = pc.actualLife + " / " + pc.life;

        if(pc.agi >= eb.initiative)
        {
            playerTurn = true;
        }else
        {
            playerTurn = false;
        }



    }



    // Update is called once per frame
    void Update()
    {

        if(!playerTurn)
        {
            enemyAttack();
            defending = false;
            preventive = false;
        }

    }

    private void enemyAttack()
    {

        if(preventive)
            damage = eb.damage + (UnityEngine.Random.Range(-1, 1)-pc.str/2);
        else if(defending)
            damage = eb.damage + (UnityEngine.Random.Range(-1, 1)-pc.str);
        else
            damage = eb.damage + (UnityEngine.Random.Range(-1, 1));

        if (damage < 0)
            damage = 0;


        pc.updateLife(pc.actualLife - damage);

        logText4.text = logText3.text;
        logText3.text = logText2.text;
        logText2.text = logText1.text;
        logText1.text = eb.monsterName+" attacked and dealt "+damage+" damage.";



        if (pc.actualLife <= 0)
        {
            SceneManager.LoadScene("Menu"); //character died.
        }else
        {
            playerHealth.text = pc.actualLife + " / " + pc.life;
            healthBarPlayer.fillAmount = (float)((pc.actualLife*100)/pc.life)/100;
        }
        
        playerTurn = true;
    }

    public void inventory()
    {
        if (playerTurn)   //not implemented yet.
        {

        }

    }

    public void run()
    {
        if (playerTurn)
        {
            if (UnityEngine.Random.Range(0, 10) <= 2)
            {
                pc.SaveData();
                SceneManager.LoadScene("Forest");   //Player Scaped.
            }
            else
            {
                logText4.text = logText3.text;
                logText3.text = logText2.text;
                logText2.text = logText1.text;
                logText1.text = "Failed to escape!";
            }

            playerTurn = false;
        }
    }

    public void defend()
    {
        if (playerTurn)
        {
            defending = true;
            logText4.text = logText3.text;
            logText3.text = logText2.text;
            logText2.text = logText1.text;
            logText1.text = "The hero is defending.";
            playerTurn = false;
        }
    }

    public void attack()
    {
        if (playerTurn)
        {
            if (UnityEngine.Random.Range(0, 1000) <= pc.critical * 10)
            {
                if(pc.usingSword == true)
                damage = (pc.str + (UnityEngine.Random.Range(-pc.str / 5, pc.str / 5))* 5);
                else
                    damage = (pc.dex + (UnityEngine.Random.Range(-pc.dex / 5, pc.dex / 5)) * 5);

                logText4.text = logText3.text;
                logText3.text = logText2.text;
                logText2.text = logText1.text;
                logText1.text = "The hero atacked and did " + damage + " damage. CRITICAL!";
            }
            else
            {
                if(pc.usingSword == true)
                damage = (pc.str + (UnityEngine.Random.Range(-pc.str / 5, pc.str / 5))* 3);
                else
                    damage = (pc.dex + (UnityEngine.Random.Range(-pc.dex / 5, pc.dex / 5)) * 3);

                logText4.text = logText3.text;
                logText3.text = logText2.text;
                logText2.text = logText1.text;
                logText1.text = "The hero atacked and did " + damage + " damage.";
            }
            eb.updateHealth(eb.remainingLife - damage);

            if (eb.remainingLife <= 0) //enemy is dead.
            {

                if (pc.idQuest == 2 && enemy.tag.Equals("slime"))
                    pc.countQuest++;

                pc.gold += eb.droppedMoney;
                pc.addExperience(eb.experienceGiven);
                pc.SaveData();
                SceneManager.LoadScene("Forest");

            }
            else
            {
                enemyHealth.text = eb.remainingLife + " / " + eb.life;
                healthBarEnemy.fillAmount = (float)((eb.remainingLife*100)/eb.life)/100;
            }

            playerTurn = false;
        }

    }


    private GameObject getMonsterFromPool(string name)
    {

        chances = UnityEngine.Random.Range(0, 100);
        if (name == "ForestFight")
        {
            if(chances >= 0) // 100% chances of a slime.
                return slime;
        }

        return slime;
    }

}
