using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{ //Deni
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpot;
    [SerializeField] private float _reloadingTime;
    [SerializeField] AudioClip _shootSound;
    private bool isRealoading;
    private bool isMinigunMode;

    //We create a if method so we can use shoot method with help of space button plus a realoding bool. But if minigun mode is active, then you don't need to press any button, it will shoot by it self
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRealoading)
        {
            Shoot();
        }
        if (isMinigunMode)
        {
            Shoot();
        }
    }
    //This method what makes our bullet to shoot. We will create instance of bullet prefap, it's position and with help of quarternion bullet will have no rotation or going to be defualt.
    private void Shoot()
    {
        if (isRealoading)
        {
            return;
        }
        var bullet = Instantiate(_bulletPrefab, _bulletSpot.position, Quaternion.identity);
        Destroy(bullet.gameObject, 5);
        StartCoroutine(Reloading());
    }
    //Before reloading bool starts, we play shooting sound then make reloading bool true. With help of our variable we will decide how long will reloading time take.
    private IEnumerator Reloading()
    {
        AudioManager.Instance.PlaySound(_shootSound);
        isRealoading = true;
        yield return new WaitForSeconds(_reloadingTime);
        isRealoading = false;
    }
    //Firstly we will make minigun mode true so we can use it. After that we will change reloading time to 0.1 seconds. After that we will create a yield seconds that we can decide-
    //how much time it will last. When it's done, we will make bool false and return it to regular reloading mode.
    public IEnumerator ActiveMinigunMode()
    {
        isMinigunMode = true;
        var saveReloadingTime = _reloadingTime;
        _reloadingTime = 0.1f;
        yield return new WaitForSeconds(10);
        isMinigunMode = false;
        _reloadingTime = saveReloadingTime;
        

    }
}





