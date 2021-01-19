using UnityEngine;
using UnityEngine.SceneManagement;

public class randomShit : MonoBehaviour
{
    public void exitGame() {
        Application.Quit();
    }

    public void reloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

}
