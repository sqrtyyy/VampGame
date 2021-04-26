using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireSounds : ISoundable 
{

    public AudioSource attackSound;
    public AudioSource deathSound;
    public AudioSource hitReactionSound;
    
    protected override void playAttackSound() {
        attackSound.Play();
    }
    protected override void playDeathSound() {
        deathSound.Play();
    }
    protected override void playHitReactionSound() {
        hitReactionSound.Play();
    }
}
