using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public void ChangeScen()
    {
        Debug.Log("Change Scene");
        SceneManager.LoadScene("BasementMain");
    }
}
