using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float speed = 1f;


    bool statsCreated = false;
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

    public int str;
    int dex;
    int mag;
    public int agi;
    int luc;
    int sta;
    int level;
    int remainingLevels;
    int experience;
    int experienceRequired;
    public double actualLife;
    public double life;
    int energy;
    int energyRate;
    public double critical;
    double dodge;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (GameObject.Find(gameObject.name)
                  && GameObject.Find(gameObject.name) != this.gameObject)
        {

            actualLife = GameObject.Find(gameObject.name).GetComponent<PlayerController>().actualLife;
            Destroy(GameObject.Find(gameObject.name));
        }
    }

    private void Start()
    {

        if (!statsCreated)
        {
            createCharacterStats();
        }

    }

    private void createCharacterStats()
    {
        str = 5;
        dex = 5;
        mag = 0;
        agi = 5;
        luc = 5;
        sta = 5;
        level = 1;
        life = 150;
        dodge = 1;
        critical = 1;
        actualLife = life;
        energy = 100;
        energyRate = 15;
        remainingLevels = 0;
        experience = 90;
        statsCreated = true;
        experienceRequired = level * 100;
    }



    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "ForestFight")
        {
            UpdateStats();
            Movement();
        }



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
