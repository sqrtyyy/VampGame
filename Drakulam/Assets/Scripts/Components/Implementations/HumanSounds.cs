using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSounds : ISoundable
{

    public AudioSource attackSound;
    public AudioSource stepSound;
    public AudioSource deathSound;
    public AudioSource hitReactionSound;
    public float stepSoundLength;
    private float prevStepSound;
    
    protected override void playAttackSound() {
        attackSound.Play();
    }

    protected override void playStepSound()
    {
        if (Time.time - prevStepSound > stepSoundLength)
        {
            stepSound.Play();
            prevStepSound = Time.time;
        }
        
    }
    protected override void playDeathSound() {
        deathSound.Play();
    }
    protected override void playHitReactionSound() {
        hitReactionSound.Play();
    }
}
