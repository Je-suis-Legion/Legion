using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurBoutons : MonoBehaviour
{
    [SerializeField] private int nbBoutons;
    private int count = 0;
    
    [SerializeField] public List<GameObject> solutionBouton;
    public List<GameObject> listBoutons;

    public void CheckList()
    {
        if (listBoutons.Count == nbBoutons)
        {
            foreach (var i in listBoutons)
            {
                if (i != solutionBouton[listBoutons.IndexOf(i)].gameObject)
                {
                    count = 0;

                    foreach (var j in listBoutons)
                    {
                        j.GetComponent<BoutonsPoussoir>().Reset();
                    }
                    
                    listBoutons.Clear();
                    break;
                }

                count++;
            }

            if (count == nbBoutons)
            {
                Destroy(gameObject);
            }
        }
    }
}
