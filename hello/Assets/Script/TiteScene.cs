using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(SceneChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange() 
    {
        SceneManager.LoadScene("PlayScene");
    }
}
