using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenserScript : MonoBehaviour
{
    public GameObject[] Items;
    public skill_ULT playerScript;
    public int SpownCount;

    void Start()
    {
        StartCoroutine(ItemsSpown());
    }

    void Update()
    {

        if (playerScript.ULT_Count1 >= 4)
        {
            StopCoroutine(ItemsSpown());
            //DestroyItems();
        }

    }

    public IEnumerator ItemsSpown()
    {


        while (true)
        {
            // �v���n�u�̈ʒu�������_���Őݒ�
            float x = Random.Range(-0.6f, 0.6f);
            float z = Random.Range(-0.5f, 0.5f);
            Vector3 pos = new Vector3(x, 1.0f, z);

            // �v���n�u�𐶐�
            Instantiate(Items[Random.Range(0, Items.Length)], pos, Quaternion.identity);

            yield return new WaitForSeconds(SpownCount);
        }

    }

    public void DestroyItems()
    {
        GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject Item in Items)
        {
            Destroy(Item);
        }
    }
}
