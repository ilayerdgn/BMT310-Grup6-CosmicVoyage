using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void SelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void SelectLevel1()
    {
        SceneManager.LoadScene("level1");
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene("level2");
    }
    public void SelectLevel3()
    {
        SceneManager.LoadScene("level3");
    }
    public void SelectLevel4()
    {
        SceneManager.LoadScene("level4");
    }
    public void SelectLevel5()
    {
        SceneManager.LoadScene("level5");
    }
}
