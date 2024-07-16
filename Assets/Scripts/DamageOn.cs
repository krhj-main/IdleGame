using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOn : MonoBehaviour
{
    public GameObject prefabDamage;
    // Äµ¹Ù½º »ý¼º

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageText()
    {
        GameObject inst = Instantiate(prefabDamage,transform);
    }
}
