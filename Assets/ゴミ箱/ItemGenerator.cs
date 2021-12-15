using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
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
        //���̋���(15m)���ƂɃA�C�e���𐶐�(for���̏����̕ϐ������̂܂�z���ɗ��p�ł���悤�ɂ��Ă���)
        for(int i = startPos; i < goalPos; i += 15)
        {
            //�ݒu����I�u�W�F�N�g���m���Ō���(20%�R�[��80%��or�R�C��)
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x��=�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiate�̂܂܂��ƃ����_���ɔz�u����邽�߁A��xGameObject�^�̕ϐ��ɓ���Ď擾���Ă���A���W���w�肵�Ă�����
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //�R�C���������͎Ԃ����[�����ɐ���
                for(int j = -1; j <= 1; j++)
                {
                    //�I�u�W�F�N�g��ݒu����z���W���炷�p�̕ϐ�
                    int offsetZ = Random.Range(-5, 6);
                    //�ݒu����I�u�W�F�N�g���m���Ō���
                    int item = Random.Range(1, 11);
                    //60%�R�C��30%��10%�����Ȃ�
                    if(1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�(�R�C�����^�����т��Ǝ�肸�炢����offset�őO��5m�ȓ��̂����ݒ�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7<= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
