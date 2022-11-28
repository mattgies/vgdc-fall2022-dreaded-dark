using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyTextMeshPro : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject player;
    public TMP_Text canvasText;
    public PlayerMovement pMove;

    private int lineNum;
    
    private bool hasTriggeredLight;
    private bool hasTriggeredLevel2;
    private bool hasEncounteredEnemies;
    private bool narration_active;

    // Start is called before the first frame update
    void Start()
    {
        lineNum = 0;
        hasTriggeredLight = false;
        hasTriggeredLevel2 = false;
        hasEncounteredEnemies = false;
        narration_active = false;

        Time.timeScale = 1f;
        //But have a time delay between each one
        canvasText.text = "My my, little fawn.";
        Invoke("activateNarration", 3f);
        /*Debug.Log(lineNum);
        Invoke("activateNarration", 3f);
        Debug.Log(lineNum);
        Invoke("activateNarration", 3f);
        Debug.Log(lineNum);
        Invoke("activateNarration", 3f);
        Debug.Log(lineNum);
        Invoke("deactivateNarration", 3f);*/

        /*Not sure where to stick this though
          canvasText.text = "Use the WASD or Arrow keys to move around";
          canvasText.text = "Press the space bar to jump";
          
          I think for the ending you'd need to trigger some kind of event?
          
          Like if Player.transform.position > the position of the last light
          Then make the screen fade
          Give the final line: canvasText.text = "You're finally free..."
          And roll the credits*/
    }

    // Update is called once per frame

    void Update()
    {
        if(narration_active == true)
        {
            pMove.prohibitMovement();
        }
    }

    //Meant for when you pass by a light/etc.
    //Probably needs a different kind of Collider because the player can't touch the text box
    
    /*void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightSwitch1") && hasTriggeredLight == false)
        {
            canvasText.text = "Press 'F' to interact";
            if(Input.GetKeyDown("F"))
            {
                canvasText.text = "Surprised?";
                //Something wait for five seconds
                canvasText.text = "The light may seem kind, but it can also blind you.";
                //Something wait for five seconds
                canvasText.text = "Press 'F' to turn the lights back off";
                hasTriggeredLight = true;
            }
            canvasText.text = "I'm afraid, poor child, that while in these dark woods, you must trust the darkness to be your ally.";
            canvasText.text = "Now, follow me.";

        }
        elif(other.CompareTag("LightSwitch3") && hasTriggeredLevel2 == false)
        {
            canvasText.text = "Well done, child. But there is still a long way to go.";
            hasTriggeredLevel2 = true;
        }
        elif(other.CompareTag("LightSwitch5") && hasEncounteredEnemies == false)
        {
            canvasText.text = "Beware. Some creatures intend to do you harm."
            canvasText.text = "Make sure you understand their movements before proceeding further."
            hasEncounteredEnemies = true;
        }
        else
        {
            return; 
        }
    }*/

    void activateNarration()
    {
        if(lineNum == 0)
        {
            canvasText.text = "My my, little fawn.";
        }
        else if(lineNum == 2)
        {
            canvasText.text = "You're a long way from the forest, aren't you?";
        }
        else if(lineNum == 3) //jumps straight to here for some reason and skips the other two lines
        {
            canvasText.text = "Scared of the dark, are you?";
        }
        else
        {
            canvasText.text = "Try that switch there.";
        }
        lineNum += 1;
        narration_active = true;
    }

    void deactivateNarration()
    {
        narration_active = false;
    }
    

}
