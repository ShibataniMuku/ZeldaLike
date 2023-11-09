using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalUIManager : MonoBehaviour
{
    [SerializeField] GameObject pivot = null;

    public void viewPivot()
    {
        this.pivot.SetActive(true);
    }

    public void hidePivot()
    {
        this.pivot.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hidePivot();
    }

    public void go_to_Scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
