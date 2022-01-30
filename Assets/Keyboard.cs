using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject blackTile, whiteTile; 
    public GameObject content;

    public int numberOfOctaves;
    // Start is called before the first frame update
    void Start()
    {
        int startNote = 24;
        for (int i = 0; i < numberOfOctaves; i++)
        {
            createOctave(startNote+i*12, i);
        }
    }


    private void createOctave(int actualNote, int octave){
        float width = content.GetComponent<RectTransform>().rect.width;
        float widthPerOctave = width / numberOfOctaves; 
        float widthPerNote = widthPerOctave / 7; 

        // 7 white tiles
        for (int i = 0; i < 7; i++)
        {
            int actualNoteIndex = getWhiteKeyIndex(i); 
        }

    }

    private int getWhiteKeyIndex(int i){
        // C
        int actualNoteIndex = 0;

        if(i == 1){
            // D
            actualNoteIndex = 2;
        } else if(i == 2){
            // E
            actualNoteIndex = 4; 
        } else if(i == 3){
            //F
            actualNoteIndex = 5; 
        }else if(i == 4){
            //G
            actualNoteIndex = 7; 
        }
        else if(i == 5){
            //A
            actualNoteIndex = 9; 
        }
        else if(i == 6){
            //A
            actualNoteIndex = 9; 
        }
        return actualNoteIndex;

    }

    private int getBlackKeyIndex(int i){
        // CS
        int actualNote = 1; 
        if(i == 1){
            // DS
            actualNote = 3; 
        } else if(i == 2){
            // ES
            actualNote = 6; 
        } else if(i == 3){
            //FS
            actualNote = 8; 
        }
        return actualNote;
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
