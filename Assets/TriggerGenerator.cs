using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGenerator : MonoBehaviour
{
    // �I�u�W�F�N�g�����g���K�[��Prefab������ϐ�������
    public GameObject gentriggerPrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�����g���K�[���A�������s������Z���̊e�n�_����-50�̊e�n�_�ɔz�u
        for (int i = startPos; i <goalPos; i += 15)
        {
            GameObject gentrigger = Instantiate(gentriggerPrefab);
            gentrigger.transform.position = new Vector3(gentrigger.transform.position.x, gentrigger.transform.position.y, i - 50);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
