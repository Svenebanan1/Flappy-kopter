using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class AmountOfFood_Delivery : MonoBehaviour
{ 
    public TextMeshProUGUI AmountText;
    
    // Start is called before the first frame update
    public TMP_Text AmountStoredText;
    public GameObject ConfirmingButton;

    //Variable for the AmountStoredText text
    public int MenuFood;
    int amountselected;
    //How much food is selected with the slider


    public int CutsceneScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameStatus");
        if (go == null)
        {
            this.enabled = false;
            return;
        }
        GameStatus gs = go.GetComponent<GameStatus>();
        AmountStoredText.text = "Current Amount: " + gs.MenuFood;

        
    }
    //If you hit the confirm button this happens \/
    public void ConfirmButton()
    {
        GameObject go = GameObject.Find("GameStatus");
        GameStatus gs = go.GetComponent<GameStatus>();

        //if You have less than 25 collected food/Not enough
        if (gs.MenuFood > 25)
        {
            Invoke("LoadCutScene", 0.5f);
        }
        //if You have 25 collected food/Enough
        else if (gs.MenuFood < 25)
        {
            Debug.Log("You have to have atleast 25 food");
        }

        
            
        
    }
    public void SetAmount(float AmountSelected)
    {
        AmountText.text = AmountSelected.ToString();
        amountselected = (int)AmountSelected;
        MenuFood -= amountselected;  
    }

    void LoadCutScene()
    {
        SceneManager.LoadScene(CutsceneScene);
    }
}
