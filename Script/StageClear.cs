using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour {

    public string nextStage;

    public float waitNext;

	public void NextStage()
    {
        SceneManager.LoadScene(nextStage);
    }
}
