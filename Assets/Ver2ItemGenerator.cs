using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ver2ItemGenerator : MonoBehaviour
{
    //�ePrefab������ϐ�������(Public�Ő錾����Inspector������)
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    //�I�u�W�F�N�g�𐶐�����x����(��)�͈̔�:-3.4�������[�������A3.4���E���[������
    private float posRange = 3.4f;
    //�I�u�W�F�N�g��������n�_(�O=Z����)
    private float unity2obj = 50;
    //�����^�C�~���O�v���p�̕ϐ�(�I�u�W�F�N�g��������Z���W������)
    private float pointA;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���J�n���ɑ�����1�񐶐����邽�߂ɑ��
        this.pointA = -15;
    }

    // Update is called once per frame
    void Update()
    {
        //�O��I�u�W�F�N�g��������Z���W����15���ꂽ�^�C�~���O�Ő���
        if(transform.position.z - this.pointA >= 15)
        {
            //��������Z���W��o�^
            this.pointA = transform.position.z;
            //�ݒu����I�u�W�F�N�g���m���Ō���(20%�R�[��80%��or�R�C��)
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x��=�������Ɉ꒼���ɐ���
                for(float j = -1;j <= 1; j += 0.4f)
                {
                    //Instantiate�̂܂܂��ƃ����_���z�u�̂��߁AGameObject�^�̕ϐ��ɓ���Ď擾���Ă���A���W���w��
                    //z���W�́A���݂�Unity�����̍��W����unity2obj�ɓ��ꂽ�l�����ꂽ�ꏊ�ɐ���
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.gameObject.transform.position.z + unity2obj);
                }
            }
            else
            {
                //�R�C���������͎Ԃ����[�����ɐ���
                for(int j = -1; j<= 1; j++)
                {
                    //�I�u�W�F�N�g��ݒu����ۂ�Z���W�����炷�p�̕ϐ�
                    int offsetZ = Random.Range(-5, 6);
                    //�ݒu����I�u�W�F�N�g���m���Ō���
                    int item = Random.Range(1, 11);
                    //60%�R�C�� 30%�� 10�������Ȃ�
                    if(1<=item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.gameObject.transform.position.z + unity2obj + offsetZ);
                    }
                    else if(7<= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.gameObject.transform.position.z + unity2obj + offsetZ);
                    }
                }
            }
        }
    }
}
