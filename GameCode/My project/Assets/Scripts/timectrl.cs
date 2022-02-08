using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timectrl : MonoBehaviour
{
    public UnityEngine.UI.Text timetext, gameStatus, btntext;
    public UnityEngine.UI.Button btn;
    public GameObject panel1, panel2;
    public movescript moveScript1, moveScript2;
    public float timecounter = 60;
    public Image panel2img;

     

    // Start is called before the first frame update
    void Start()
    {
        panel1 = GameObject.Find("Panel"); panel1.SetActive(false);
        panel2img = GameObject.Find("Panel2").GetComponent<Image>();
        panel2 = GameObject.Find("Panel2"); panel2.SetActive(false);
        
       
    }

    void Awake()
    {
        moveScript1 = GameObject.Find("Male").GetComponent<movescript>();
        moveScript2 = GameObject.Find("Female").GetComponent<movescript>();
    }
    // Update is called once per frame
    void Update()
    {
        timecounter -= Time.deltaTime;
        timetext.text = "TIME :" + (int)timecounter;

        if(timecounter < 0 ||moveScript1.fallState== true || moveScript2.fallState == true)
        {
            gameStatus.text = "GAME OVER";
            panel1.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            btntext.text = "Try Again";
            btn.gameObject.SetActive(true);

            panel2img.color = new Color(0, 0 , 0);
            timetext.text = " ";

        }

        if(moveScript1.winState== true && moveScript2.winState== true)
        {
            gameStatus.text = "YOU WIN";
            panel1.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            btntext.text = "Play Again";
            btn.gameObject.SetActive(true);
            
            panel2img.color = new Color(0, 0.85f, 0.08f);
        }
    }

    
}
