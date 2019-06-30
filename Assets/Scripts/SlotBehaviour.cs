using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public bool isEmpty;
    public Sprite icon;
    public TextMeshProUGUI numberOfItems;
    public Button imageButton;
    public PlayerController pc;
    public FightController fc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isEmpty = true;
    }

    public void displayImage()
    {
        imageButton.GetComponent<Image>().sprite = icon;
        imageButton.GetComponent<Image>().enabled = true;
    }

    public void displayQuantity()
    {
        numberOfItems.text =  quantity.ToString();
    }


    public void cleanSlot()
    {
        isEmpty = true;
        itemName = null;
        imageButton.GetComponent<Image>().enabled = false;
        numberOfItems.text = "";
    }


    public void interactItem()
    {
        foreach(GameObject item in pc.inventory)
        {
            var ib = item.GetComponent<ItemBehaviour>();
            if (itemName.Equals(ib.itemName))
            {
                if (ib.isConsumable)
                {
                    if (ib.isHealingItem)
                    {
                        if((pc.actualLife += (ib.healingQuantity * pc.life) / 100) > pc.life)
                        {
                            pc.actualLife = pc.life;
                        }else
                        {
                            pc.actualLife += (ib.healingQuantity * pc.life) / 100;
                        }

                        if (SceneManager.GetActiveScene().name == "ForestFight")
                            fc.playerTurn = false;



                    }

                    quantity--;
                    displayQuantity();
                    if (quantity == 0)
                    {
                        cleanSlot();
                    }


                    pc.inventory.Remove(item);

                }

                break;
            }
        }
    }

}
