using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //This script will save player's data.
    public static GameController Instance;
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


    void Awake()
    {
        if (Instance == null)
        {
            str = 5;
            dex = 10;
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
            experienceRequired = level * 100;
            idQuest = 1;
            textQuest = "Speak with Lucius at town.";
            countQuest = 0;
            requiredQuest = 0;
            gold = 50;
            usingSword = true;



            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


}
