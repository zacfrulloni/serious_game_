using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Unlock_Area : MonoBehaviour
{
    // Start is called before the first frame update
    private int level = 0;


    private GameObject grid_child;

    private GameObject level_one_blockers;

    private GameObject level_two_blockers;

    private GameObject level_three_blockers;

    private Level_Bar_Manager current_level;
    void Start()
    {
        // Get the LevelDivider children in Grid
        GameObject grid_object = GameObject.Find("Grid");
        grid_child = grid_object.transform.GetChild(5).gameObject;
        level_one_blockers = grid_child.transform.GetChild(0).gameObject;
        level_two_blockers = grid_child.transform.GetChild(1).gameObject;
        level_three_blockers = grid_child.transform.GetChild(2).gameObject;


        // Get the current level objects in LevelingSystem
        GameObject level_object = GameObject.Find("LevelingSystem");
        GameObject current_level_object = level_object.transform.GetChild(3).gameObject;
        current_level = current_level_object.GetComponent<Level_Bar_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        // If level goes up, delete divider associated with that level + 1
        if (level != current_level.level){
            level = current_level.level;
            if (level >= 2) {
                Destroy(level_one_blockers);
            }
            if (level >= 3) {
                Destroy(level_two_blockers);
            }
            if (level >= 4) {
                Destroy(level_three_blockers);
            }
        }
    }
}
