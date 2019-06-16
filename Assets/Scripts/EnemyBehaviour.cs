using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public double life;
    public double remainingLife;
    public int damage;
    public int initiative;
    public GameObject[] loot;
    public int experienceGiven;
    public int droppedMoney;
    public string monsterName;



    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag.Equals("slime"))
        {

            monsterName = "Slime";
            life = 50 + (Random.Range(-10, 10));
            remainingLife = life;
            damage = 4 + (Random.Range(-2, 2));
            droppedMoney = 5 + (Random.Range(-1, 1));
            initiative = 5;
            experienceGiven = 10;
            loot = null;

        }
    }

    public void updateHealth(double HP)
    {
        remainingLife = HP;
    }

}
