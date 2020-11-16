using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerCoin = 10;
    //[SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] List<Sprite> List = new List<Sprite>();
    [SerializeField] Image scores;
    // Start is called before the first frame update

    void Awake()
    {
        //scores.GetComponent<Image>().sprite = List[0];
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void resetPoints() 
    {
        currentScore = 0;
        scores.GetComponent<Image>().sprite = List[0];
    }

    public void AddToScore()
    {
        currentScore += pointsPerCoin;
        scores.GetComponent<Image>().sprite = List[1];
    }
}
