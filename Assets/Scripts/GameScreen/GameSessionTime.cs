using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameSessionTime : MonoBehaviour
{
    [SerializeField] private Text _time;

    private void Start()
    {
        StartCoroutine(UpdatedTime());
    }
    
    IEnumerator UpdatedTime()
    {
        int interval = 1;
        int second = 0;
        int minute = 0;

        while (true)
        {
            _time.text = (minute.ToString().Length != 2 ? $"0{minute}" : $"{minute}") + ":" + (second.ToString().Length != 2 ? $"0{second}" : $"{second}"); 

            yield return new WaitForSeconds(interval);

            second++;

            if (second == 60)
            {
                second = 0;
                minute++;
            }
        }
    }
}
