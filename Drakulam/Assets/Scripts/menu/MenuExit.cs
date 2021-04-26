using UnityEngine;

public class MenuExit : MonoBehaviour
{
   public void QuitApp()
   {
      Debug.Log("Quit");
      Application.Quit();
   }
   
   void Update()
      {
         if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
         {
            Debug.Log("Quit");
            Application.Quit();    // закрыть приложение
         }
      }
}
