using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuActions : MonoBehaviour
{
   public void IniciaJogo()
   {
      SceneManager.LoadScene(1);
      GameController.Init();
      
   }

   public void Menu()
   {
      SceneManager.LoadScene(0);
   }
}
