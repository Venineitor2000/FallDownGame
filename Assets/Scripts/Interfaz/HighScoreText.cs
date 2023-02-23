using UnityEngine;
using TMPro;
public class HighScoreText : MonoBehaviour
{ 
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.GetHighScore().ToString();
    }
}
