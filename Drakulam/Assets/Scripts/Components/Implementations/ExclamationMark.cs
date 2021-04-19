using UnityEngine;
using Utils;

public class ExclamationMark : MonoBehaviour
{
    public bool canBeSabotaged;
    
    private PlayerInfo.CharacterClass _characterClass;
    private bool _isActive;
    private bool _isInitialized;
    
    private const string _animatorIsActive = "isActive";
    private const string _animatorIsHuman = "isHuman";
    private Animator _animator;

    private const string _debugPrefix = "EXMARK";
    
    void Awake()
    {
        _animator = GetComponent<Animator>();

        _isInitialized = false;
        _isActive = false;
        
        UpdateAnimator();
    }
    
    /*
     * change status of exclamation mark (after changing character class):
     * active -> not active
     * to
     * not active -> active
     *
     * must be called after updating status of task
     */
    public void ChangeStatus()
    {
        if (!_isInitialized ||
            (_characterClass == PlayerInfo.CharacterClass.Vampire && !canBeSabotaged && !_isActive))
        {
            return;
        }

        _isActive = !_isActive;
        UpdateAnimator();
    }

    /*
     * set player character class
     */
    public void SetPlayerClass(PlayerInfo.CharacterClass characterClass)
    {
        if (_isInitialized && _characterClass == characterClass)
            // nothing changed, return
            return;

        _characterClass = characterClass;
        
        if (!_isInitialized)
        {
            // was not initialized before, initialize
            _isInitialized = true;
            if (_characterClass == PlayerInfo.CharacterClass.Human)
                _isActive = true;
            UpdateAnimator();
        }
        else
        {
            ChangeStatus();
        }
    }

    /*
     * update animator variables
     */
    private void UpdateAnimator()
    {
        _animator.SetBool(_animatorIsHuman, _isInitialized && _characterClass == PlayerInfo.CharacterClass.Human);
        _animator.SetBool(_animatorIsActive, _isInitialized && _isActive);
    }
}