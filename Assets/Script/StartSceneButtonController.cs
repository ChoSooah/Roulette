using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButtonController : MonoBehaviour
{

    public void WaterButtonClick()
    {
        SceneManager.LoadScene("GameSceneWater");
    }

    public void FireButtonClick()
    {
        SceneManager.LoadScene("GameSceneFire");
    }

    public void GrassButtonClick()
    {
        SceneManager.LoadScene("GameSceneGrass");
    }

}
