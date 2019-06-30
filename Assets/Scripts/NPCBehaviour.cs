using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour
{

    GameObject hero;
    public GameObject textBar;
    public GameObject menubar;
    public GameObject shopPanel;
    public MenuController mc;
    public TextMeshProUGUI chatTitle;
    public TextMeshProUGUI chatText;
    public bool talkingAvailable;
    public Sprite charImage;
    public Sprite charImageTalking;
    public List<GameObject> shopStock;
    public GameObject shopGrid;


    void Start()
    {

        hero = GameObject.FindGameObjectWithTag("Player");
        talkingAvailable = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(hero.transform.position, this.gameObject.transform.position) < 1.4)
        {
            talkingAvailable = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = charImageTalking;
        } else
        {
            talkingAvailable = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = charImage;
        }


        if (Input.GetKeyDown(KeyCode.E) && talkingAvailable)
            ChitChat();

        if (Input.GetKeyDown(KeyCode.Q) && talkingAvailable)
            openStore();


    }



    public void ChitChat()
    {
        if (this.gameObject.tag.Equals("lucius"))
        {
            if (hero.GetComponent<PlayerController>().idQuest == 1)
            {

                textBar.SetActive(true);
                chatTitle.text = "Lucius Lawstroke";
                chatText.text = "Son... I need you to take care of those Slimes outside the town. They have been increasing their numbers and they are starting to be a menace to the city walls. Remember what i taught you and come back to me when you are done.";
                menubar.SetActive(false);

                hero.GetComponent<PlayerController>().idQuest = 2;
                hero.GetComponent<PlayerController>().countQuest = 0;
                hero.GetComponent<PlayerController>().requiredQuest = 3;
                hero.GetComponent<PlayerController>().textQuest = "Kill slimes " + hero.GetComponent<PlayerController>().countQuest + " / " + hero.GetComponent<PlayerController>().requiredQuest;

            } else if (hero.GetComponent<PlayerController>().idQuest == 2 && hero.GetComponent<PlayerController>().countQuest >= hero.GetComponent<PlayerController>().requiredQuest)
            {
                textBar.SetActive(true);
                menubar.SetActive(false);
                chatTitle.text = "Lucius Lawstroke";
                chatText.text = "You killed them already ? Town's guard will be proud of you, son. Here, take some gold coins.";

                mc.quitQuestTracker();
                hero.GetComponent<PlayerController>().idQuest = 0;
                hero.GetComponent<PlayerController>().countQuest = 0;
                hero.GetComponent<PlayerController>().requiredQuest = 0;
                //add money and experience.

            }
            else
            {
                textBar.SetActive(true);
                menubar.SetActive(false);
                chatTitle.text = "Lucius Lawstroke";
                chatText.text = "How are you doing Son ? Did you finish with your chores already?";
            }
        }


        if (this.gameObject.tag.Equals("clarissa")) {
            textBar.SetActive(true);
            menubar.SetActive(false);
            chatTitle.text = "Clarissa Goldtrade";
            chatText.text = "Nice and sunny day we have, huh ? Are you interested in something at my store ?";
        }



    }


    public void openStore()
    {
        if (this.gameObject.tag.Equals("clarissa"))
        {
            shopPanel.SetActive(true);

            for (int i = 0; i < 1; i++)
            {
               shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().cleanSlot();
            }

                foreach (GameObject item in shopStock)
            {
                var ib = item.GetComponent<ItemBehaviour>();

                for(int i = 0; i <= 1; i++)
                {
                    if (shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().isEmpty)
                    {
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().isEmpty = false;
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().shopItem = item;
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().icon = ib.icon;
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().itemName = ib.itemName;
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().value = ib.value;
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().showIcon();
                        shopGrid.transform.GetChild(i).GetComponent<shopSlotBehaviour>().showText();
                        break;

                    }
                }

            }


        }




        }
}
