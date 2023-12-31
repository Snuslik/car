﻿namespace ClassLibrary1
{
    public class Car
    {
        public string LicensePlate { get; } = " Ц202ОИ 777 RUS";
        public int Speed { get; protected set; } = 0;
        protected bool EngineRunning = false;
        public int CurrentGear { get; protected set; } = 0;

        public virtual string CarName => "Mustang";
        public virtual int MaxSpeed => 120;

        public virtual bool Gas()
        {
            if (!EngineRunning || CurrentGear == 0)
            {
                return false;
            }

            int increaseAmount = 10;
            AdjustSpeedByGear(increaseAmount);

            return true;
        }

        protected void AdjustSpeedByGear(int increaseAmount)
        {
            if (CurrentGear == -1 && Speed + increaseAmount > 30) increaseAmount = 30 - Speed;
            if (CurrentGear == 1 && Speed + increaseAmount > 30) increaseAmount = 30 - Speed;
            if (CurrentGear == 2 && Speed + increaseAmount > 50) increaseAmount = 50 - Speed;
            if (CurrentGear == 3 && Speed + increaseAmount > 70) increaseAmount = 70 - Speed;
            if (CurrentGear == 4 && Speed + increaseAmount > 90) increaseAmount = 90 - Speed;
            if (CurrentGear == 5 && Speed + increaseAmount > MaxSpeed) increaseAmount = MaxSpeed - Speed;

            Speed += increaseAmount;
        }

        public bool Brake()
        {
            if (Speed == 0)
            {
                Console.WriteLine("Скорость нулевая");
                return false;
            }

            if (CurrentGear == 0)
            {
                Console.WriteLine("Измените передачу");
                return false;
            }

            int decreaseAmount = 10;
            AdjustSpeedByGear(-decreaseAmount);



            if (CurrentGear == 1 && Speed < 0) { Speed = 0; }
            if (CurrentGear == 2 && Speed < 20) { SetGear(1); }
            if (CurrentGear == 3 && Speed < 40) { SetGear(2); }
            if (CurrentGear == 4 && Speed < 60) { SetGear(3); }
            if (CurrentGear == 5 && Speed < 80) { SetGear(4); }

            return true;
        }

        public virtual string StartEngine()
        {
            if (CurrentGear != 0 && CurrentGear != 1)
            {
                EngineRunning = false;
                return $"Двигатель заглох на {CarName}" + LicensePlate;
            }

            EngineRunning = true;
            return $"Двигатель запущен на {CarName}" + LicensePlate;
        }

        public string StopEngine()
        {
            EngineRunning = false;
            return $"Машина {CarName} заглушена";
        }

        public bool SetGear(int gear)
        {
            if (gear < -1 || gear > 5)
            {
                return false;
            }

            if (gear == -1 && Speed != 0)
            {
                return false;
            }

            CurrentGear = gear;
            return true;
        }

        public bool Reverse()
        {
            if (!EngineRunning || CurrentGear != 0)
            {
                return false;
            }

            Speed = 0;
            return true;
        }
    }

    public class CarType2 : Car
    {
        public override string CarName => "Subaru";
        public override int MaxSpeed => 150;

        public override bool Gas()
        {
            if (!EngineRunning || CurrentGear == 0)
            {
                return false;
            }

            int increaseAmount = 10;
            AdjustSpeedByGear(increaseAmount);

            return true;
        }


    }

    public class CarType3 : Car
    {
        public override string CarName => "Supra";
        public override int MaxSpeed => 200;

        public override bool Gas()
        {
            if (!EngineRunning || CurrentGear == 0)
            {
                return false;
            }

            int increaseAmount = 20;
            AdjustSpeedByGear(increaseAmount);

            return true;
        }


    }
}
