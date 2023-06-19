using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGeneretor : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject cornPrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //unitychanを入れる
    public GameObject unitychan;
    //アイテムを生成する最小距離
    public int DistanceitemgeneretorMin = 40;
    //アイテムを生成する最大距離
    public int DistanceitemgeneretorMax = 50;
    //アイテムを生成する間隔
    public int generetioninterval = 10;
    //最後にアイテムを生成した位置
    public int lastgeneretion = 40;

    

    // Start is called before the first frame update
    void Start()
    {
        //unitychanを取得
        this.unitychan = GameObject.Find("unitychan");


       
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムをunityちゃんの位置から40∼50ｍも範囲で生成し、ゴール以上には生成しないように設定
      if((unitychan.transform.position.z + DistanceitemgeneretorMin + DistanceitemgeneretorMax > lastgeneretion) &  (unitychan.transform.position.z + DistanceitemgeneretorMin + DistanceitemgeneretorMax +generetioninterval < goalPos))
        {
            //iを使うために設定
            int i = lastgeneretion + generetioninterval;
            lastgeneretion += generetioninterval;


            //どのアイテムを出すのかランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {

                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab);
                    cornPrefab.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }

            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くｚ座標のオフセットをランダムに設定
                    int offsetz = Random.Range(-5, 6);
                    //60%コインを配置：30％車を配置：10％何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetz);

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetz);
                    }
                }
            }
        }
    }
}
