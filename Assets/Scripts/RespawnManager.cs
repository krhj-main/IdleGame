using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();

    public Transform SpawnManager;
    public GameObject[] Mobs;

    public int objCnt = 1;

    private void Awake()
    {
        for (int i = 0; i < Mobs.Length; i++)
        {
            for (int j = 0; j < objCnt; j++)
            {
                /*
                GameObject gg = CreateObj(Mobs[i],SpawnManager);
                MobPool.Add(gg);
                */
                MobPool.Add(CreateObj(Mobs[i],SpawnManager));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateMob());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj,parent);
        copy.SetActive(false);

        return copy;
    }
    int DeactiveMob()
    {
        List<int> num = new List<int>();

        for (int i = 0; i < MobPool.Count; i++)
        {
            if (!MobPool[i].activeSelf)
            {
                num.Add(i);
            }
        }

        int x = 0;
        if (num.Count > 0)
        {
            x = num[Random.Range(0, num.Count)];
            num.Remove(x);    
        }
        
        return x;
    }
    IEnumerator CreateMob()
    {
        while (true)
        {
            MobPool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f,3f));
        }
    }
}
