using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchLevelTransition : MonoBehaviour
{

    //initialising variables for effect (customizable)
    private AnalogGlitch glitchEffect;
    private AudioSource glitchNoise;
    private float glitch_time = 5.0f;
    private float glitch_strength = 0.35f;
    private float glitch_decay = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        glitchEffect = GetComponent<AnalogGlitch>();
        glitchNoise = GetComponent<AudioSource>();
        glitchNoise.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // public variables to access:
        // scanLineJitter, verticalJump, horizontalShake, colourDrift

        if (glitch_time > 0f)
        {
            // reduces glitch strength then reduces glitch time
            glitch_strength = Mathf.Max(0, glitch_strength - glitch_decay * Time.deltaTime);
            glitch_time -= Time.deltaTime;
            //changes glitch variables for visual effect
            glitchEffect.scanLineJitter = glitch_strength;
            glitchEffect.verticalJump = glitch_strength;
            glitchEffect.horizontalShake = glitch_strength;
            glitchEffect.colorDrift = glitch_strength;
            glitchNoise.volume = glitch_strength;
            
        }

        else
        {
            glitchEffect.scanLineJitter = 0;
            glitchEffect.verticalJump = 0;
            glitchEffect.horizontalShake = 0;
            glitchEffect.colorDrift = 0;
            glitchNoise.volume = 0;
        }

    }
}
