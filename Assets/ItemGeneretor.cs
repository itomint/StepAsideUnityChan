using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGeneretor : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject cornPrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //unitychan������
    public GameObject unitychan;
    //�A�C�e���𐶐�����ŏ�����
    public int DistanceitemgeneretorMin = 40;
    //�A�C�e���𐶐�����ő勗��
    public int DistanceitemgeneretorMax = 50;
    //�A�C�e���𐶐�����Ԋu
    public int generetioninterval = 15;
    //�Ō�ɃA�C�e���𐶐������ʒu
    public int lastgeneretion = 40;

    

    // Start is called before the first frame update
    void Start()
    {
        //unitychan���擾
        this.unitychan = GameObject.Find("unitychan");


       
    }

    // Update is called once per frame
    void Update()
    {

      if((unitychan.transform.position.z + DistanceitemgeneretorMin + DistanceitemgeneretorMax > lastgeneretion) &  (unitychan.transform.position.z + DistanceitemgeneretorMin + DistanceitemgeneretorMax +generetioninterval < goalPos))
        {

            int i = lastgeneretion + generetioninterval;
            lastgeneretion += generetioninterval;


            //�ǂ̃A�C�e�����o���̂������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {

                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab);
                    cornPrefab.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }

            }
            else
            {

                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u�������W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetz = Random.Range(-5, 6);
                    //60%�R�C����z�u�F30���Ԃ�z�u�F10�������Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetz);

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetz);
                    }
                }
            }
        }
    }
}
