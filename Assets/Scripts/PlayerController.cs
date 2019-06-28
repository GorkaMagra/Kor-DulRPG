using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float speed = 1f;

    public TextMeshProUGUI strTxt;
    public TextMeshProUGUI dexTxt;
    public TextMeshProUGUI magTxt;
    public TextMeshProUGUI agiTxt;
    public TextMeshProUGUI lucTxt;
    public TextMeshProUGUI staTxt;
    public TextMeshProUGUI lvlTxt;
    public TextMeshProUGUI xpTxt;
    public TextMeshProUGUI aLifeTxt;
    public TextMeshProUGUI lifeTxt;
    public TextMeshProUGUI energyTxt;
    public TextMeshProUGUI energyRateTxt;
    public TextMeshProUGUI criticalTxt;
    public TextMeshProUGUI dodgeTxt;
    public TextMeshProUGUI questTxt;
    public TextMeshProUGUI goldTxt;

    public int str;
    public int dex;
    public int mag;
    public int agi;
    public int luc;
    public int sta;
    public int level;
    public int remainingLevels;
    public int experience;
    public int experienceRequired;
    public double actualLife;
    public double life;
    public int energy;
    public int energyRate;
    public double critical;
    public double dodge;
    public int idQuest;
    public string textQuest;
    public int countQuest;
    public int requiredQuest;
    public List<GameObject> inventory;
    public int gold;
    public bool usingSword;



    private void Start()
    {
       loadData();
    }


    public void SaveData()
    {
        GameController.Instance.str = str;
        GameController.Instance.dex = dex;
        GameController.Instance.mag = mag;
        GameController.Instance.agi = agi;
        GameController.Instance.luc = luc;
        GameController.Instance.sta = sta;
        GameController.Instance.level = level;
        GameController.Instance.remainingLevels = remainingLevels;
        GameController.Instance.experience = experience;
        GameController.Instance.experienceRequired = experienceRequired;
        GameController.Instance.actualLife = actualLife;
        GameController.Instance.life = life;
        GameController.Instance.energy = energy;
        GameController.Instance.energyRate = energyRate;
        GameController.Instance.critical = critical;
        GameController.Instance.dodge = dodge;
        GameController.Instance.idQuest = idQuest;
        GameController.Instance.textQuest = textQuest;
        GameController.Instance.countQuest = countQuest;
        GameController.Instance.requiredQuest = requiredQuest;
        GameController.Instance.inventory = inventory;
        GameController.Instance.gold = gold;
        GameController.Instance.usingSword = usingSword;
    }


    public void loadData()
    {
        str = GameController.Instance.str;
        dex = GameController.Instance.dex;
        mag = GameController.Instance.mag;
        agi = GameController.Instance.agi;
        luc = GameController.Instance.luc;
        sta = GameController.Instance.sta;
        level = GameController.Instance.level;
        remainingLevels = GameController.Instance.remainingLevels;
        experience = GameController.Instance.experience;
        experienceRequired = GameController.Instance.experienceRequired;
        actualLife = GameController.Instance.actualLife;
        life = GameController.Instance.life;
        energy = GameController.Instance.energy;
        energyRate = GameController.Instance.energyRate;
        critical = GameController.Instance.critical;
        dodge = GameController.Instance.dodge;
        idQuest = GameController.Instance.idQuest;
        textQuest = GameController.Instance.textQuest;
        countQuest = GameController.Instance.countQuest;
        requiredQuest = GameController.Instance.requiredQuest;
        inventory = GameController.Instance.inventory;
        gold = GameController.Instance.gold;
        usingSword = GameController.Instance.usingSword;
    }



    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "ForestFight")
        {
            UpdateStats();
            Movement();
        }

        if (idQuest == 2)
            questTxt.text = "Kill slimes " + countQuest + " / " + requiredQuest;



    }

    private void Movement()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f,speed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        }

    }

    public void useSword()
    {
        usingSword = true;
    }

    public void useDagger()
    {
        usingSword = false;
    }


    private void UpdateStats()
    {
        strTxt.text = str.ToString();
        dexTxt.text = dex.ToString();
        magTxt.text = mag.ToString();
        agiTxt.text = agi.ToString();
        lucTxt.text = luc.ToString();
        staTxt.text = sta.ToString();
        aLifeTxt.text =  actualLife.ToString()+" / "+life.ToString();
        lifeTxt.text = life.ToString();
        dodgeTxt.text = dodge.ToString();
        criticalTxt.text = critical.ToString();
        energyTxt.text = energy.ToString();
        energyRateTxt.text = energyRate.ToString();
        goldTxt.text = gold.ToString()+" Gold.";
        if (idQuest != 0)
            questTxt.text = textQuest.ToString();
        //lvlTxt.text = level.ToString();
        //xpTxt.text = experience.ToString();
    }


    public void addExperience(int receivedExperience)
    {
        experience += receivedExperience;
        if(experience >= experienceRequired)
        {
            levelUp();
            experience = experience - experienceRequired;
            experienceRequired = level * 100 + level*10 + level*1;

        }
    }
    
    private void levelUp()
    {
        level++;
        remainingLevels += 3;
    }

    private void addSTR()
    {
        str++;
    }

    private void addDEX()
    {
        dex++;
    }

    private void addMAG()
    {
        mag++;
    }

    private void addAGI()
    {
        agi++;
        dodge += 0.2;
        energyRate++; 

    }

    private void addLUC()
    {
        luc++;
        critical += 0.2;
    }

    private void addSTA()
    {
        sta++; 
        life += 10 + (sta / 10);
        energy += 2 + (energy / 20);
    }

    public void updateLife(double HP)
    {
        actualLife = HP;
    }







}
