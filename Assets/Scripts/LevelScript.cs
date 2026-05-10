using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelScript : Base_Level_Component
{
    [SerializeField] private Level_uI uI_Level;
    [SerializeField] private Animator _TransitionAnim;
    //[SerializeField] private float TrailTime;
    [SerializeField] private float countdownSpeed;
    [SerializeField] private float remainingTime;
    private float baseInterval;
    public override void InitalizeComponent()
    {
        baseInterval = 1;
    }

    public override void ResetComponent()
    {
        StopAllCoroutines();
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }
    IEnumerator ChallengeTimer(float time)
    {
        Debug.Log("Challenge start!");
        float waitTime = baseInterval / countdownSpeed;
        while (time > 0)
        {
            yield return new WaitForSeconds(waitTime);
            time -= countdownSpeed;
            uI_Level.gameplayTexts.Find(x => x.name == "Timerleft").text = displayTimer(time);
            //Debug.Log(displayTimer(time));
        }

        FailedChallenge();
    }
    private void FailedChallenge()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Tile>().NotifyObserver(PlayerState.Player_Dead);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Tile>().NotifyObserver(PlayerState.);
        GameManager.instance.GetLevelManager().LoadMainMenu();
        Debug.Log("GAME OVER: back to main menu!");
    }

    public string displayTimer(float currentTime_)
    {
        float minutes = Mathf.FloorToInt(currentTime_ / 60);
        float seconds = Mathf.FloorToInt(currentTime_ % 60);
        string result = string.Format("{0:00}:{1:00}", minutes, seconds);
        return result;
    }
    // Start is called before the first frame update
    void Start()
    {
        //uI_Level = GameObject.FindAnyObjectByType<Level_uI>();
        baseInterval = 1;
        //GameManager.instance.GetSoundManager().PlayMusicClip("Nic8bit");
    
    }
    public void StartChallege(float tmp_)
    {
        
        StartCoroutine(ChallengeTimer(tmp_));
        //currentChallengeSwitch = currentswitch_;
        //currentChallengeSwitch.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void LostChance()
    {
        GameManager.instance.SetNumberOfChances(GameManager.instance.GetNumberofChances() - 1);
        Debug.Log("Tries: " + GameManager.instance.GetNumberofChances());
        GameManager.instance.CheckChances();
        uI_Level.UpdateChanceUI(GameManager.instance.GetNumberofChances());
        //GameManager.instance.SetCurrnetLevel(0);
    }
    // Update is called once per frame
    public IEnumerator LoadLevel()
    {
        _TransitionAnim.SetTrigger("Start_FadeOut");

        yield return new WaitForSeconds(1);

        GameManager.instance.GetLevelManager().NextLevel();
    }
    public void StartLevelSequence()
    {
        uI_Level.gameplayTexts.Find(x => x.name == "Timerleft").text = displayTimer(0);
        StartChallege(10);
    }
    void Update()
    {

    }
}
    