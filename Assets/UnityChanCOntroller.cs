using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanCOntroller : MonoBehaviour
{
    //Animator�R���|�[�l���g�����邽�߂̕ϐ���p��
    private Animator myAnimator;
    //RigidBody�R���|�[�l���g�����邽�߂̕ϐ���p��(�ړ������邽��)
    private Rigidbody myRigidbody;
    //�O�����̑��x
    private float velocityZ = 16f;
    //�������̑��x
    private float velocityX = 10f;
    //������̑��x
    private float velocityY = 10f;
    //���E�̈ړ��ł���͈�
    private float movableRange = 3.4f;
    //�Q�[���I�����Ɍ���������W��
    private float coefficient = 0.99f;
    //�Q�[���I���̔���
    private bool isEnd = false;
    //�Q�[���I�����e�L�X�g�̃I�u�W�F�N�g�����邽�߂̕ϐ���p��
    private GameObject stateText;
    //�X�R�A�\���e�L�X�g�̃I�u�W�F�N�g�����邽�߂̕ϐ���p��
    private GameObject scoreText;
    //�X�R�A
    private int score = 0;
    //���{�^�������̔���
    private bool isLButtonDown = false;
    //�E�{�^�������̔���
    private bool isRButtonDown = false;
    //�W�����v�{�^�������̔���
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();
        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed", 1);
        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();
        //GameResultText�I�u�W�F�N�g���擾
        this.stateText = GameObject.Find("GameResultText");
        //ScoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I���̏ꍇUnity�����̓���������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        //�������̈ړ��ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;
        //Unity�����̍��E�ړ�(���E���L�[�������͍��E�{�^��)
        if((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            inputVelocityX = this.velocityX;
        }
        //�W�����v���Ă��Ȃ��Ƃ��ɃX�y�[�X��J�{�^���������ꂽ��W�����v����
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //�W�����v�A�j�����Đ�
            this.myAnimator.SetBool("Jump", true);
            //������ւ̑��x����
            inputVelocityY = this.velocityY;
        }
        else
        {
            //���݂�Y���̑��x����
            inputVelocityY = this.myRigidbody.velocity.y;
        }
        //Jump�X�e�[�g�̏ꍇ��Jump��false���Z�b�g(true�����͂��ꑱ����Ɩ����ɃA�j���[�V�������Ă��܂���)
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //Rigidbody�R���|�[�l���g(�N���X)�ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }
    //�g���K�[(Collider)�Ɣw�H�����ꍇ�̏���
    void OnTriggerEnter(Collider other)
    {
        //��Q���ɏՓ˂����ꍇ
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            //GAME OVER�\��
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }
        //�S�[���n�_�ɓ��B�����ꍇ
        if(other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //GAME CLEAR�\��
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        //�R�C���ɏՓ˂����ꍇ
        if(other.gameObject.tag == "CoinTag")
        {
            //�X�R�A�����Z
            this.score += 10;
            //ScoreText�Ɋl�������_���𔽉f
            scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
            //�p�[�e�B�N�����Đ�
            GetComponent<ParticleSystem>().Play();
            //�ڐG�����R�C���̃I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }
    }
    //�e��{�^����������������ꍇ�̏���
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GeyMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }
    public void GeyMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
