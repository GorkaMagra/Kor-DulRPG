using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shopSlotBehaviour : MonoBehaviour
{
    public bool isEmpty;
    public Image image;
    public Sprite icon;
    public int value;
    public string itemName;
    public GameObject shopItem;
    public TextMeshProUGUI text;
    public PlayerController pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isEmpty = true;
    }

    public void showText()
    {
        text.text = itemName + " - " + value + " Gold";
    }
    public void showIcon()
    {
        image.GetComponent<Image>().sprite = icon;
        image.GetComponent<Image>().enabled = true;
    }

    public void cleanSlot()
    {
        isEmpty = true;
        image.GetComponent<Image>().enabled = false;
        text.text = " ";
    }


    public void buyItem()
    {
       if(pc.gold >= value) //User can buy it.
        {
            pc.gold -= value;
            pc.inventory.Add(shopItem);           
        }
    }



}
