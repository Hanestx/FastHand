namespace FastHand
{
    public class PlayerShooting
    {
        public IWeapon Weapon {get; set; }


        public void Shoot()
        {
            Weapon.Shoot();
        }
    }
}