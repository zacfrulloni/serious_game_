using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Bar_Manager : MonoBehaviour, Game_Interface_Data
{
    private bool levelUpSceneLoaded = true;
    public Image levelbar;
    private int level_progress = 0;

    // public DialogueController DialogueControl;
    private int points;
    private float fill;
    private float level_progress_required = 90f;
    public int level;
    
    private Player_Pickup player;

    // Start is called before the first frame update
    void Start()
    {   
        // Find Player, and get the player's points
        GameObject player_object = GameObject.Find("Player");
        if (player_object != null) {
            player = player_object.GetComponent<Player_Pickup>();
            player.points = 0;
        }    
        
        else {
            Debug.LogError("Player gameobject is not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If player points are updated and level bar is not full, update level bar as well
        if (levelbar.fillAmount != 1.0f) {
            // DialogueControl.Start();
            level_progress = player.points;
            levelbar.fillAmount = fill + (level_progress / (level_progress_required * level));
            if (level >= 2 && level <= 4 && !levelUpSceneLoaded)
            {
                SceneManager.LoadScene("level_up_dialog");
                levelUpSceneLoaded = true;
                Debug.Log("HELLO");
            }
        }

        // If level bar is full, restart bar and update level
        else if (levelbar.fillAmount == 1.0f) {
            levelbar.fillAmount = 0.0f;
            fill = 0f;
            level_progress = 0;
            player.points = 0;
            level ++;
        }
    }

    public void LoadData(Game_Data data) {
        this.level = data.playerLevel;
        this.levelbar.fillAmount  = data.barFillAmount;
        this.points = data.playerPoints;
    }

    public void SaveData(ref Game_Data data) {
        data.playerLevel = this.level;
        data.barFillAmount = this.levelbar.fillAmount;
        data.playerPoints = this.points;
    }
}
