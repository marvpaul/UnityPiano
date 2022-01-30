using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGen : MonoBehaviour
{
    /* 
    Created by Marvin Krueger
    This file was created by us. We used a method for sound generation which was intially mentioned here: https://www.youtube.com/watch?v=GqHFGMy_51c and adjusted it for our purposes
     */
    float sampleRate;
    AudioSource audioSource;

    public Dictionary<int, List<float>> frequencies;

    List<float> phase, increment; 
 
    void Awake()
    {
        sampleRate = AudioSettings.outputSampleRate;
        phase = new List<float>{0,0};
        increment = new List<float>{0,0};
        frequencies = new Dictionary<int, List<float>>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = true;
    }

    public void OnKey(int keyNumber){
        // https://www.inspiredacoustics.com/en/MIDI_note_numbers_and_center_frequencies
        float freq = 440 * Mathf.Pow(2, ((float)keyNumber-69f)/12f); 
        frequencies[keyNumber] = new List<float>{freq, 0};
    }

    public void changePitch(int keyNumber, float pitch){
        try{
        frequencies[keyNumber][1] = pitch;

        } catch{
            Debug.Log("Not yet here");
        }
    }

    public void onKeyOff(int keyNumber){
        frequencies.Remove(keyNumber);
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    
   
    void OnAudioFilterRead(float[] data, int channels)
    {
        // General idea from here --> https://www.youtube.com/watch?v=GqHFGMy_51c 
        int counter = 0;
        try{
            foreach (var item in frequencies.Keys){
                for(int i = 0; i < data.Length; i+= channels)
                {          
                    float freq = frequencies[item][0];
                    float vibratoAmount = frequencies[item][1];
                    float incrementAmount = (freq + freq/10*vibratoAmount) * 2f * Mathf.PI/ sampleRate;
                    phase[counter] += incrementAmount;
                    data[i] += (float) (Mathf.Sin(phase[counter]));
                    if(phase[counter] > (Mathf.PI*2f)){
                        phase[counter] = 0f; 
                    }
                }
                counter ++;
            }
        } catch{
            Debug.Log("Accesing while changing the frequency");
        }
        
    }
}
