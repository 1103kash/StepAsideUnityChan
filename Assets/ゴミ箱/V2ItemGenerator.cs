using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2ItemGenerator : MonoBehaviour
{
    // �ePrefeb������ϐ�������(Public�Ő錾����Inspector������)
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x����(��)�͈̔�:-3.4�������[��������3.4���E���[������
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Unity����񂪒ʉ߂����ۂ�50m��ɃI�u�W�F�N�g�𐶐�
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "UnityTag")
        {
            //�ݒu����I�u�W�F�N�g���m���Ō���(20���R�[��80����or�R�C��)
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //�R�[����x��=�������Ɉ꒼���ɐ���
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiate�̂܂܂��ƃ����_���ɔz�u����邽�߁A��xGameObject�^�̕ϐ��ɓ���Ď擾���Ă���A���W���w��
                    //Z���ɂ��ẮA���̃X�N���v�g���A�^�b�`�����g���K�[�p�I�u�W�F�N�g����50m��n�_���w��
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.gameObject.transform.position.z + 50);
                }
            }
            else
            {
                //��or�R�C�������[�����ɐ���
                for (int j = -1;j <= 1; j++)
                {
                    //�I�u�W�F�N�g��ݒu����z���W��O��ɂ��炷���߂̕ϐ�
                    int offsetZ = Random.Range(-5, 6);
                    //��or�R�C�����m���Ō���
                    int item = Random.Range(1, 11);
                    //60���R�C��30����10�������Ȃ�
                    if(1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.gameObject.transform.position.z + 50 + offsetZ);
                    }
                    else if(7<=item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.gameObject.transform.position.z + 50 + offsetZ);
                    }
                }
            }
        }
    }
}
