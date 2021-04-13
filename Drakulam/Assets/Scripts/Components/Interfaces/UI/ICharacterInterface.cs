using UnityEngine;
using UnityEngine.UI;

public abstract class ICharacterInterface : MonoBehaviour
{
    public abstract void SetUI(string uiName);
    public abstract void UpdateTaskList();

    public abstract void SetMaxHealth(int healthPoints);

    public abstract void UpdateHealthBar(int healthPoints);

    public abstract void UpdateTimer(int minutes, int seconds);

    public UnityEngine.UI.Slider healthBar;

    public static Transform taskList;

    public Text timerText;
}
