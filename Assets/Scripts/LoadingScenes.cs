using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    public static LoadingScenes Instance;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        { 
            Destroy(gameObject);        
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(string name, float delay)
    {
        StartCoroutine(InstanceScene(name, delay));
    }

    IEnumerator InstanceScene(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(name);
    }
}
