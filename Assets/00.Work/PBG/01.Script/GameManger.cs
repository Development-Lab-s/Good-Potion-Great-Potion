using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance{get; private set;}

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    
}
