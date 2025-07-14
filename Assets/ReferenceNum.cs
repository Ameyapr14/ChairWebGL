using UnityEngine;

public class ReferenceNum : MonoBehaviour
{
    public static ReferenceNum Instance { get; private set; }
    [SerializeField] public int RefNum;
    public int itemNum; 


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ViewPressed(int num)
    {
        RefNum = num;
        Debug.Log(RefNum);
    }
}
