using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyTextMeshPro : MonoBehaviour
{
    public TMP_Text canvasText;
    public TMP_Text tutorial;
    public TMP_Text deathCount;
    public int numDeaths; 
    public PlayerDeath pDead;

    public string[] narration;
    public string[] instructions;

    public int narrationIndex;
    public int instructionIndex;

    // Start is called before the first frame update
    void Start()
    {
        narration[0] = "My my, little fawn.";
        narration[1] = "You're a long way from the forest, aren't you?";
        narration[2] = "Scared of the dark, are you?";
        narration[3] = "Try that switch there.";

        instructions[0] = "Press 'F' to interact";

        narration[4] = "Surprised?";
        narration[5] = "The light may seem kind, but it can also blind you.";

        instructions[1] = "Press 'F' to turn the lights back off";

        narration[6] = "I'm afraid, poor child, that while in these dark woods, you must trust the darkness to be your ally.";
        narration[7] = "Now, follow me.";

        instructions[2] = "Use the WASD or Arrow keys to move around";
        instructions[3] = "Press the space bar to jump";

        narration[8] = "Well done, child. But there is still a long way to go.";
        narration[9] = "Beware. Some creatures intend to do you harm.";
        narration[10] = "Make sure you understand their movements before proceeding further.";

        narration[11] = "Finally, you're free.";

        pDead = new PlayerDeath();
        numDeaths = 0; 
        narrationIndex = 0;
        instructionIndex = 0;

        canvasText.text = "Some text";
        string textVariable = "Some Text 2";
    }

    // Update is called once per frame
    void Update()
    {
        numDeaths = pDead.getDeathCount();
        deathCount.text = "Deaths: " + numDeaths;
    }
}
