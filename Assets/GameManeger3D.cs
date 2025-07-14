using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManeger3D : MonoBehaviour
{
    public bool backpressed;
  
    [SerializeField] public GameObject[] ViewModels;
    [SerializeField] public CameraOrbit Cam;
    public int count;

    void OnEnable()
    {
       
        RefreshCount();
        CheckNum();
    }

    void RefreshCount()
    {
        backpressed = false;
        count = ReferenceNum.Instance.itemNum;
        Debug.Log("RefNum now = " + count);
    }

    public void CheckNum()
    {
        for (int i = 0; i < ViewModels.Length; i++)
        {
            ViewModels[i].SetActive(false);
        }
       ViewModels[count].SetActive(true);
        Cam.target = ViewModels[count].transform;
    }


    public void PreviousSceneLoad()
    {
        backpressed = true;
        SceneManager.LoadScene("Chairwebgl");
    }
}
