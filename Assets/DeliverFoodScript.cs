using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class DeliverFoodScript : MonoBehaviour
{
    public bool IfButtonClicked;

    public GameObject MenuCanvas;
    public GameObject CutSceneAnimation;
    public GameObject CutSceneBackground;
    public GameObject ConfirmingButton;
    public GameObject DeliverFoodPanel;
    //Variable for the AmountStoredText text
    public int MenuFood;
    int amountselected;
    public int CutsceneScene;
    //How much food is selected with the slider
    public TMP_Text AmountStored;
    public TMP_Text AmountStars;
    public TextMeshProUGUI AmountText;
    public TMP_Text DeliveredFood;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameStatus");
        GameStatus gs = go.GetComponent<GameStatus>();
        if (go == null)
        {
            this.enabled = false;
            return;
        }
        AmountStored.text = "Current Amount: " + gs.MenuFood;
        DeliveredFood.text = "Delivered Food: " + gs.DeliveredFood;
        AmountStars.text = "Stars: " + gs.Stars;

        if (IfButtonClicked == true)
        {
            Invoke("LoadCutScene", 0.5f);
        }

    }
    //If you hit the confirm button this happens \/
    public void ConfirmButton()
    {
        GameObject go = GameObject.Find("GameStatus");
        GameStatus gs = go.GetComponent<GameStatus>();

        //Script for when you click button and have enough
        if (gs.MenuFood >= 25 && amountselected >= 25 && amountselected < gs.MenuFood)
        {
            //Adds to delivered food by how much you selected
            gs.DeliveredFood += amountselected;
            gs.MenuFood -= amountselected;
            if (gs.DeliveredFood % 25 >= 0 || gs.DeliveredFood % 25 < 25)
            {
                gs.Stars++;
                
            }
            IfButtonClicked = true;
        }
        //Script for when you click confirm and have enough + If you try to select more than you have
        else if (gs.MenuFood >= 25 && amountselected >= 25 && amountselected >= gs.MenuFood)
        {
            gs.DeliveredFood += gs.MenuFood;
            gs.MenuFood -= gs.MenuFood;
            if (gs.DeliveredFood % 25 >= 0 || gs.DeliveredFood % 25 < 25)
            {
                gs.Stars++;
            }
            IfButtonClicked = true;
        }
        //if You don't have 25 food
        else if (gs.MenuFood < 25)
        {
            Debug.Log("You have to Have atleast 25 food");
        }
        //if you haven't selected more than 25 food
        else if(amountselected < 25)
        {
            Debug.Log("You have to deliver atleast 25 food");
        }
    }
    public void SetAmount(float AmountSelected)
    {
        AmountText.text = AmountSelected.ToString();
        amountselected = (int)AmountSelected;
    }

    public void LoadCutScene()
    {
        MenuCanvas.SetActive(false);
        CutSceneAnimation.SetActive(true);
        CutSceneBackground.SetActive(true);
        DeliverFoodPanel.SetActive(false);
        IfButtonClicked = false;
    }

    public void OpenDeliverFoodPanel()
    {
        DeliverFoodPanel.SetActive(true);
    }
}
