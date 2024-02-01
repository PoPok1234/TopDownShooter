using UnityEngine;

public class Weapon : Entity
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootingPosition;

    [SerializeField] private GameObject[] guns;

    public int damage { get; set; }

    public bool mayShot { get; set; }

    private float waitForShot = 0.5f;

    [SerializeField] private GunType gunType;
    private enum GunType { player, enemy}
    protected EnemySpawner manager;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        manager = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        waitForShot -= Time.deltaTime;
        if (gunType == GunType.player)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                waitForShot = 1f;
                manager.isPistol = true;
                guns[0].SetActive(true);
                guns[1].SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                waitForShot = 0.2f;
                manager.isPistol = false;
                guns[0].SetActive(false);
                guns[1].SetActive(true);
            }

            if (Input.GetMouseButton(0) && waitForShot <= 0)
            {
                Instantiate(bullet, shootingPosition.position, transform.rotation);
                if (guns[0].activeSelf)
                    waitForShot = 1f;
                else
                    waitForShot = 0.2f;
            }
        }

        if(gunType == GunType.enemy)
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);

            if(waitForShot <= 0 && mayShot)
            {
                Instantiate(bullet, shootingPosition.position, shootingPosition.rotation);
                waitForShot = 1f;
            }
        }

    }
}
