using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanCOntroller : MonoBehaviour
{
    //Animatorコンポーネントを入れるための変数を用意
    private Animator myAnimator;
    //RigidBodyコンポーネントを入れるための変数を用意(移動させるため)
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 16f;
    //横方向の速度
    private float velocityX = 10f;
    //上方向の速度
    private float velocityY = 10f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //ゲーム終了時に減速させる係数
    private float coefficient = 0.99f;
    //ゲーム終了の判定
    private bool isEnd = false;
    //ゲーム終了時テキストのオブジェクトを入れるための変数を用意
    private GameObject stateText;
    //スコア表示テキストのオブジェクトを入れるための変数を用意
    private GameObject scoreText;
    //スコア
    private int score = 0;
    //左ボタン押下の判定
    private bool isLButtonDown = false;
    //右ボタン押下の判定
    private bool isRButtonDown = false;
    //ジャンプボタン押下の判定
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
        //GameResultTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");
        //ScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム終了の場合Unityちゃんの動きを減衰
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        //横方向の移動による速度
        float inputVelocityX = 0;
        //上方向の入力による速度
        float inputVelocityY = 0;
        //Unityちゃんの左右移動(左右矢印キーもしくは左右ボタン)
        if((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            inputVelocityX = this.velocityX;
        }
        //ジャンプしていないときにスペースかJボタンが押されたらジャンプする
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }
        //Jumpステートの場合はJumpにfalseをセット(trueが入力され続けると無限にアニメーションしてしまう為)
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //Rigidbodyコンポーネント(クラス)に速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }
    //トリガー(Collider)と背食した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            //GAME OVER表示
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }
        //ゴール地点に到達した場合
        if(other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //GAME CLEAR表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        //コインに衝突した場合
        if(other.gameObject.tag == "CoinTag")
        {
            //スコアを加算
            this.score += 10;
            //ScoreTextに獲得した点数を反映
            scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();
            //接触したコインのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }
    //各種ボタンを押下･離した場合の処理
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
