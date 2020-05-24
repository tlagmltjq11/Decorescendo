using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : SingletonMonoBehaviour<SceneManage>
{
    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
