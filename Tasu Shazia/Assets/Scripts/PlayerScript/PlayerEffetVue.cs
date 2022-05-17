using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffetVue : MonoBehaviour
{
    public List<GameObject> listObjetsVue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveEffetVue()
    {
        foreach (var i in listObjetsVue)
        {
            i.SetActive(true);
        }
    }
    
    public void DesactiveEffetVue()
    {
        foreach (var i in listObjetsVue)
        {
            i.SetActive(false);
        }
    }
}
