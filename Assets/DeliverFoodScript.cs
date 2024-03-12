using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEditor;

public class DeliverFoodScript : MonoBehaviour
{
    public GameObject CutSceneChildren;
    public GameObject MenuCanvas;
    public GameObject CutSceneAnimation;
    public GameObject CutSceneBackground;
    public GameObject ConfirmingButton;
    public GameObject DeliverFoodPanel;
    //Variable for the AmountStoredText text
    int amountselected;
    public int CutsceneScene;
    //How much food is selected with the slider
    public TMP_Text AmountStored;
    public TMP_Text AmountFamiliesSaved;
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
        AmountFamiliesSaved.text = "SavedFamilies: " + gs.SavedFamilies;

        

    }
    //If you hit the confirm button this happens \/
    public void ConfirmButton()
    {
        GameObject go = GameObject.Find("GameStatus");
        GameStatus gs = go.GetComponent<GameStatus>();

        //Script for when you click button and have enough
        if (gs.MenuFood >= 25 && amountselected >= 25 && amountselected < gs.MenuFood)
        {
            //Adds to delivered food, how much you selected
            gs.DeliveredFood += amountselected;
            gs.MenuFood -= amountselected;
            if (gs.DeliveredFood % 25 >= 0 || gs.DeliveredFood % 25 < 25)
            {
                gs.SavedFamilies++;
            }
            LoadCutScene();
        }
        //Script for when you click confirm and have enough + If you try to select more than you have
        else if (gs.MenuFood >= 25 && amountselected >= 25 && amountselected >= gs.MenuFood)
        {
            gs.DeliveredFood += gs.MenuFood;
            gs.MenuFood -= gs.MenuFood;
            if (gs.DeliveredFood % 25 >= 0 || gs.DeliveredFood % 25 < 25)
            {
                gs.SavedFamilies++;
            }
            LoadCutScene();
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
        Invoke("KidsScene", 3.15f);
    }
    void KidsScene()
    {
        CutSceneAnimation.SetActive(false);
        CutSceneChildren.SetActive(true);
        CutSceneBackground.SetActive(false);
        Invoke("BackToMenu", 3.5f);
    }
    void BackToMenu()
    {
        CutSceneChildren.SetActive(false);
        MenuCanvas.SetActive(true);
        
    }
}
