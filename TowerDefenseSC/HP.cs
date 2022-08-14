using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    float Hp = 20f;
    GameObject HealtBar;
    Text HPBarText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goober")
        {
            Hp = Hp - 1 ;
            HPBarText.text = "HealthPoint:" + Hp;
            if (Hp < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HealtBar = GameObject.FindGameObjectWithTag("HPBar");
       HPBarText= HealtBar.GetComponent<Text>();
        HPBarText.text = "HealthPoint"+Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
