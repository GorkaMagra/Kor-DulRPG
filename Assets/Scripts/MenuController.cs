using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    GameObject scroll;
    GameObject charSheet;
    GameObject menuBar;
    GameObject questTracker;
    GameObject textBar;
    GameObject inventory;
    GameObject inventoryGrid;
    public PlayerController pc;
    GameObject shop;
    GameObject equipment;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            inventoryGrid = GameObject.FindGameObjectWithTag("grid");
            pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            inventory = GameObject.FindGameObjectWithTag("inventory");
            inventory.SetActive(false);

            if (SceneManager.GetActiveScene().name == "Town")
            {
                textBar = GameObject.FindGameObjectWithTag("chatBox");
                textBar.SetActive(false);

                shop = GameObject.FindGameObjectWithTag("shop");
                shop.SetActive(false);


            }

            if (SceneManager.GetActiveScene().name != "ForestFight")
            {
                charSheet = GameObject.FindGameObjectWithTag("charSheet");
                charSheet.SetActive(false);

                questTracker = GameObject.FindGameObjectWithTag("questTracker");

                scroll = GameObject.FindGameObjectWithTag("menu");
                scroll.SetActive(false);
                menuBar = GameObject.FindGameObjectWithTag("optionsBar");

                equipment = GameObject.FindGameObjectWithTag("equipment");
                equipment.SetActive(false);
            }



        }

       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Town"); // Start the game when "New Game" it's pressed.
    }

    public void FinishGame() // Finish the game (Not functional at the unity editor).
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); // Back to the menu
    }

    public void ResumeGame()
    {
        scroll.SetActive(false);
    }

    public void quitEquipment()
    {
        equipment.SetActive(false);
    }

    public void quitBar()
    {
        textBar.SetActive(false);
        menuBar.SetActive(true);
    }

    public void quitInventory()
    {
        inventory.SetActive(false);
    }

    public void quitQuestTracker()
    {
        questTracker.SetActive(false);
    }

    public void quitShop()
    {
        shop.SetActive(false);
    }


    public void fadeCharSheet()
    {
        charSheet.SetActive(false);
    }


    public void showInventory()
    {
        inventory.SetActive(true);


        for (int i = 0; i < 7; i++)
        {
            inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().cleanSlot();

        }


        foreach (GameObject item in pc.inventory)
        {
            var ib = item.GetComponent<ItemBehaviour>();

            for (int i = 0; i < 7; i++)
            {

                if (inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().isEmpty)
                {
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().isEmpty = false;
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().itemName = ib.itemName;
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().quantity = 1;
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().icon = ib.icon;

                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().displayImage();
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().displayQuantity();

                    break;
                }
                else if (inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().itemName.Equals(ib.itemName))
                {
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().quantity++;
                    inventoryGrid.transform.GetChild(i).GetComponent<SlotBehaviour>().displayQuantity();
                    break;
                }

            }


        }

    }

}
