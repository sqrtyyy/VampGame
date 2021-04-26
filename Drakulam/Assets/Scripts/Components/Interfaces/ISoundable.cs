using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISoundable : MonoBehaviour {

    public enum SoundName
    {
        ATTACK_SOUND,
        HIT_SOUND,
        HIT_REACTION_SOUND,
        STEP_SOUND,
        TASK_SOUND,
        DEATH_SOUND,
        SOUNDS_COUNT,
    }

    public void playSound(SoundName soundName)
    {
        switch (soundName)
        {
            case SoundName.ATTACK_SOUND:
                playAttackSound();
                break;
            case SoundName.HIT_SOUND:
                playHitSound();
                break;
            case SoundName.HIT_REACTION_SOUND:
                playHitReactionSound();
                break;
            case SoundName.STEP_SOUND:
                playStepSound();
                break;
            case SoundName.TASK_SOUND:
                playTaskSound();
                break;
            case SoundName.DEATH_SOUND:
                playDeathSound();
                break;

        }
    }

    protected virtual void playAttackSound() { }
    protected virtual void playHitSound() { }
    protected virtual void playHitReactionSound() { }
    
    protected virtual void playStepSound() { }
    protected virtual void playTaskSound() { }
    protected virtual void playDeathSound() { }
}
