using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffLight : MonoBehaviour
{
    public Light light;
    private bool onOff;
    public float MinTime;
    public float MaxTime;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        OnOff();
    }
    IEnumerator OnOffdfasf()
    {
        
        yield return new WaitForSeconds(1.0f);
        onOff = true;
    }
    void onOfLight()
    {
        if (onOff)
        {
            light.enabled = !light.enabled;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
 
    void OnOff()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            light.enabled = !light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }




    }
}
