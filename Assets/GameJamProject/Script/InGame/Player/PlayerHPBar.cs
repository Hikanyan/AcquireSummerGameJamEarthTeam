using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : PlayerParameter
{
    //�ő�HP�ƌ��݂�HP�B
    PlayerParameter _maxHp = default;
    PlayerParameter _currentHp = default;
    //Slider������
    public Slider _slider;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        _slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        _currentHp = _maxHp;
        Debug.Log("Start currentHp : " + _currentHp);
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnTriggerEnter(Collider collider)
    {
        //Enemy�^�O�̃I�u�W�F�N�g�ɐG���Ɣ���
        if (collider.gameObject.tag == " ")
        {
            //�_���[�W��1�`100�̒��Ń����_���Ɍ��߂�B
            int damage = Random.Range(1, 100);
            Debug.Log("damage : " + damage);

            //���݂�HP����_���[�W������
            //_currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + _currentHp);

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            //slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + _slider.value);
        }
    }
}
