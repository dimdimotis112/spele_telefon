using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
   
   public void ReplayGame()
   {
	   SceneManager.LoadScene("Spele");
   }
   
   public void QuitGame()
   {
	   Application.Quit();
   }
}
