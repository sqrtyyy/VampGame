using UnityEngine;

public class MenuExit : MonoBehaviour
{
   public void QuitApp()
   {
      Debug.Log("Quit");
      Application.Quit();
   }
}
