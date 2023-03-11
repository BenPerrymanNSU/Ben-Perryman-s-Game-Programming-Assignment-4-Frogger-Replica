/*
    TitleUi.cs is specifically made for the main menu scene, it controls
    ui elements and saves values changed on the title.
*/
using UnityEngine;
using UnityEngine.UI;

public class TitleUi : MonoBehaviour
{
    public Text MainMenuUIStore;
    public Image SettingsMenu;
    public Text CarSpeedNum;
    public Text SpawnSpeedNum;
    public Slider CarSpeedSlider;
    public Slider SpawnSpeedSlider;
    public InputField PlayerNameInp;
    public Button PlayButton;

    public static float CarSpeed = 0f;
    public static float SpawnSpeed = 1f;
    public static string playerName = "";
    private bool Pressed = false;

    // On start, set sliders and input fields to the
    // last saved values and disables the play button
    // when the input field is empty.
    void Start(){
        CarSpeedSlider.value = CarSpeed;
        SpawnSpeedSlider.value = SpawnSpeed;
        PlayerNameInp.text = playerName;
        if (playerName == ""){
            PlayButton.enabled = false;
        }
    }

    // Checks if the user press escape and calls the
    // function that brings up the settings menu.
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("SettingButtonClick", 0f);
        }
    }

    // Re-enables the play button, attached to the
    // value change in the input field.
    public void PlayButtonUnlock(){
        PlayButton.enabled = true;
    }

    // determines if the settings button was pressed,
    // if pressed then hide main menu elements and 
    // display settings menu elements instead, if
    // pressed again do the opposite.
    public void SettingButtonClick(){
        if(Pressed == false){
            MainMenuUIStore.gameObject.SetActive(false);
            SettingsMenu.gameObject.SetActive(true);
            Pressed = true;
        }
        else if(Pressed == true){
            MainMenuUIStore.gameObject.SetActive(true);
            SettingsMenu.gameObject.SetActive(false);
            Pressed = false;
        }
    }

    // Saves value chosen through slider and display
    // in respective text box.
    public void SpawnSpeedChanger(){
        SpawnSpeed = SpawnSpeedSlider.value;
        SpawnSpeedNum.text = SpawnSpeed.ToString();
    }

    // Saves value chosen through slider and display
    // in respective text box.
    public void CarSpeedChanger(){
        CarSpeed = CarSpeedSlider.value;
        CarSpeedNum.text = CarSpeed.ToString();
    }

    // Saves the player's name as a value.
    public void PlayerNameSet(){
		playerName = PlayerNameInp.text.ToString();
	}
}
