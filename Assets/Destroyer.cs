using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g���擾����ϐ���p��
    private GameObject Unitychan;
    //Unity�����Ƃ̋���������ϐ���p��
    private float distanceUni2Me;
    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.Unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Unity�����ƃI�u�W�F�N�g�̊Ԃ̋�����}��
        this.distanceUni2Me = Unitychan.transform.position.z - this.transform.position.z;
        //��ʂ��猩�؂ꂽ��(Unity����񂩂猩��Z������=����8.0f���ꂽ��)Destroy�Ŏ��g��j��
        if(this.distanceUni2Me >= 8.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
