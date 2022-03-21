using System;

namespace Class_Work_1.Models
{
    public class Weapon
    {
        private int _magazineSize;
        private bool _autoFireMode;

        private int MagazineSize
        {
            get => _magazineSize;
            set
            {
                if (value <= 100)
                {
                    _magazineSize = value;
                }
            }
        }

        private int InMagazineBullet { get; set; }

        private bool AutoFireMoDe
        {
            get => _autoFireMode;
            set => _autoFireMode = value;
        }
        
        public Weapon()
        {
            ChangeMagazineSize();
            ChangeBulletCount();
            Start();

        }

        private void Shoot()
        { 
            if (InMagazineBullet != 0)
            {
                InMagazineBullet = InMagazineBullet - 1; 
            }
            else
            {
                AlertMessage(1);
            }
            WeaponInfo();
        }

        private void Fire()
        {
            if (_autoFireMode)
            {
                if (InMagazineBullet != 0)
                {
                    InMagazineBullet = 0;
                }
                else
                {
                    AlertMessage(1);
                }
            }
            else
            {
                if (InMagazineBullet != 0)
                {
                    InMagazineBullet = InMagazineBullet - 1;
                }
                else
                {
                    AlertMessage(1);
                }
            }
           
            
            WeaponInfo();
        }

        private void GetRemainBulletCount()
        {
            if (InMagazineBullet > 0)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"➡ Lazın olan güllə sayı: {(_magazineSize - InMagazineBullet).ToString()}");
                Console.WriteLine("-----------------------------------------------------");

            }
            else
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("➡ Maqazin tam doludur!");
                Console.WriteLine("-----------------------------------------------------");
            }
            
        }

        private void Reload()
        {
            if (InMagazineBullet == _magazineSize)
                AlertMessage(6);
            else
            {
                InMagazineBullet = _magazineSize;
                WeaponInfo();
            }
        }

        private void ChangeFireMode()
        {
            AutoFireMoDe = !AutoFireMoDe;
            WeaponInfo();
        }

        private void ChangeMagazineSize()
        {
            TryAgainForMagazineSize:
            MagazineSize = ReadLineInt("Maqazinin ölçüsünü daxil edin");
            if (_magazineSize < 0)
            {
                AlertMessage(4);
                goto TryAgainForMagazineSize;
            }
            else
            {
                if ( _magazineSize == 0)
                {
                    AlertMessage(2);
                    goto TryAgainForMagazineSize;
                }
            }
        }

        private void ChangeBulletCount()
        {
            TryAgainForInMagazineBullet:
            InMagazineBullet = ReadLineInt("Maqazindəki güllə sayını daxil edin");
            if (InMagazineBullet < 0)
            {
                AlertMessage(3);
                goto TryAgainForInMagazineBullet;
            }
            else
            {
                if (InMagazineBullet > MagazineSize)
                {
                    AlertMessage(5);
                    goto TryAgainForInMagazineBullet;
                }
            }
        }

        private void AlertMessage(int messageNum)
        {
            switch (messageNum)
            {
                case 1:
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Gülləniz bitdi! ( Relod etmək üçün 4 rəqəmini daxil edin! )");
                    break;
                    
                case  2:
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Maqazin limiti 100-dür! Yenidən cəhd edin!");
                    Console.WriteLine("-----------------------------------------------------");
                    break;
                case 3:
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Güllə sayı mənfi ola bilməz! Yenidən cəhd edin!");
                    Console.WriteLine("-----------------------------------------------------");

                    break;
                case 4:
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Maqazin tutumu mənfi ola bilməz! Yenidən cəhd edin!");
                    Console.WriteLine("-----------------------------------------------------");

                    break;
                case 5:
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Güllə sayı maqazin tutumundan çox ola bilməz! Yenidən cəhd edin!");
                    Console.WriteLine("-----------------------------------------------------");

                    break;
                case 6:
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Maqazin tam doludur!");
                    Console.WriteLine("-----------------------------------------------------");

                    break;
            }
        }

        private void WeaponInfo()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Your magazine size: {_magazineSize.ToString()} || Your remaining bullet: {InMagazineBullet.ToString()} || Your fire mode: {(_autoFireMode ? "full auto" : "single")}");
            Console.WriteLine("-----------------------------------------------------");

        }

        private void StartInfo()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("0 - İnformasiya almaq üçün\n1 - Shoot metodu üçün\n2 - Fire metodu üçün\n3 - GetRemainBulletCount metodu üçün\n4 - Reload metodu üçün\n5 - ChangeFireMode metodu üçün\n6 - Proqramı dayandırmaq üçün\n7 - Editləmək üçün");
            Console.WriteLine("-----------------------------------------------------");
        }

        private void Start()
        {
            int inChoice;
            StartInfo();
            do
            {
                inChoice = ReadLineInt("Əməliyyat nömrəsi daxil edin (info almaq üçün 0 daxil edin)");
                switch (inChoice)
                {
                    case 0:
                        StartInfo();
                        break;
                    case 1:
                        Shoot();
                        break;
                    case 2:
                        Fire();
                        break;
                    case 3:
                        GetRemainBulletCount();
                        break;
                    case 4:
                        Reload();
                        break;
                    case 5:
                        ChangeFireMode();
                        break;
                    case 6:
                        Console.WriteLine("Program dayandırıldı!");
                        break;
                    case 7:
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("8.Maqazin ölçüsünü dəyişin.\n9.Güllə sayını dəyişin.");
                        Console.WriteLine("---------------------------------");
                        break;
                    case 8:
                        ChangeMagazineSize();
                        break;
                    case 9:
                        ChangeBulletCount();
                        break;
                    default:
                        Console.WriteLine("Yanlış əməlliyat! 1 və 6 arası rəqəm daxil edin!");
                        break;
                } 
            } while (inChoice != 6);
        }
        
        private string ReadLineStr(string message= "String daxil edin")
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }
        
        private int ReadLineInt(string message = "Rəqəm daxil edin")
        {
            TryAgain:
            try
            {
                return Convert.ToInt32(ReadLineStr(message));
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Yanlış əməliyyat! Yenidən cəhd edin!");
                goto TryAgain;
            }
        }

    }
}