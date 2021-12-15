using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorV2 : MonoBehaviour
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
    //Unity�����̃I�u�W�F�N�g���擾���邽�߂̕ϐ���p��
    private GameObject unitychan;
    //Unity����񂩂猩�đO����(Z������)50m��
    private float fiftyMahead;
    
    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Unity����񂩂猩��50m���Z�����v�Z
        this.fiftyMahead = this.unitychan.transform.position.z + 50;
        //Unity����񂩂猩��50m�悪�AZ:80�̎� or 80���琔����15�̔{���̎�(������80-360�͈̔�)�ɃI�u�W�F�N�g�𐶐�
        if(this.fiftyMahead == 80 || ((this.fiftyMahead - 80) % 15 == 0 && 80 <= this.fiftyMahead && this.fiftyMahead <= 360))
        if(Mathf.Approximately(float.Parse(this.fiftyMahead.ToString("f2")), 80.0f) || (Mathf.Approximately(float.Parse(this.fiftyMahead.ToString("f2")) % 15 , 0.0f) && 80 <= this.fiftyMahead && this.fiftyMahead <= 360))
        {
            //�ȍ~�ALesson6��Start�֐��ňꊇ�Ő�������ۂƓ��l(����Z����50m��n�_�ɕύX�����̂�)
            //�ݒu����I�u�W�F�N�g���m���Őݒ�(20���R�[��80����or�R�C��)
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //�R�[����x��=�������Ɉ꒼���ɐ���
                for(float j = -1; j<=1;j += 0.4f)
                {
                    //Instantiate�̂܂܂��ƃ����_���z�u�̂��߁A��xGameObject�^�̕ϐ��ɓ���Ď擾���Ă�����W���w��
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, fiftyMahead);
                }
            }
            else
            {
                //�R�C���������͎Ԃ����[�����ɐ���
                for(int j = -1;j <= 1; j++)
                {
                    //�I�u�W�F�N�g��ݒu����ۂ�Z���W��O��ɂ��炷�ׂ̕ϐ�
                    int offsetZ = Random.Range(-5, 6);
                    //�ݒu����I�u�W�F�N�g���m���Ō���
                    int item = Random.Range(1, 11);
                    //60���R�C��30����10�������Ȃ�
                    if(1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�(�R�C�����^�����т��Ǝ�肸�炢����offset�őO��5m�ȓ��̂����ݒ�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, fiftyMahead + offsetZ);
                    }
                    else if (7<= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, fiftyMahead + offsetZ);
                    }
                }
            }
        }
    }
}
