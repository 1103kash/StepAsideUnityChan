using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g���擾���邽�߂̕ϐ���p��
    private GameObject unitychan;
    //Unity�����ƃJ�����̋���
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //�X�^�[�g���_�ł�Unity�����ƃJ�����̈ʒu(z)�̍������߂ĕϐ��ɓ����
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unity�����̈ʒu�Ƃ̍��ɍ��킹�ăJ�����ʒu���ړ�
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
