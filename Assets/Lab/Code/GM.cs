using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //So we can use UI system


#pragma warning disable CS0649  //Stop the warning about no assignment, as it will be assigned in IDE

public class GM : MonoBehaviour
{

    [SerializeField]
    Text ScoreText; //Link in IDE

    static GM sSingleton;

    int mScore;

    private void Awake()
    {
        if (sSingleton == null) //Create Singleton
        {
            sSingleton = this;
            DontDestroyOnLoad(gameObject);
            Debug.Assert(ScoreText!=null,"Score Text needs to be linked in IDE");
            StartGame();

        } else if (sSingleton!=this)
        {
            Destroy(gameObject);
        }
    }

    void StartGame()
    {
        Score = 0;
    }
    
    public static  int Score {      //Using a Setter to set core in Canvas whenever it changes
        get {
            return sSingleton.mScore;   //Get Score
        }
        set {
            sSingleton.mScore = value;
            sSingleton.ScoreText.text = string.Format("Score:{0}", sSingleton.mScore);
        }
    }
}
