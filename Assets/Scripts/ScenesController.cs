using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    float old_pos_x;
    float old_pos_y;

    private void Start()
    {

        old_pos_x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        old_pos_y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag.Equals("forestEntry") && "Player".Equals(collision.gameObject.tag))
        {
            SceneManager.LoadScene("Forest");
        }

        if (this.gameObject.tag.Equals("townEntry") && "Player".Equals(collision.gameObject.tag))
        {
            SceneManager.LoadScene("Town");
        }

    }
    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "Forest") //combat scene
        {

            if (old_pos_x != GameObject.FindGameObjectWithTag("Player").transform.position.x || old_pos_y != GameObject.FindGameObjectWithTag("Player").transform.position.y)
                {

                if(Random.Range(1, 1000) <= 5)
                {
                    old_pos_x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
                    old_pos_y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
                    SceneManager.LoadScene("ForestFight");
                }

                }
            old_pos_x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
            old_pos_y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
           
        }
    }

    private void backFromFight()
    {

    }

}


