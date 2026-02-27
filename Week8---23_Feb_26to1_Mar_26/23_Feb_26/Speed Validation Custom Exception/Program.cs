namespace Speed_Validation_Custom_Exception
{
    class SpeedInvalidException : Exception
    {
        public SpeedInvalidException(string message) : base(message)
        {

        }
    }

    class CarSpeed
    {
        public int speed { get; set; }
    }

    class CarSpeedImplementation
    {
        public void SetCarSpeed(CarSpeed sp, int speed)
        {
            if (speed >= 30 && speed <= 90)
            {
                sp.speed = speed;
                Console.WriteLine("Speed Set Successfully");
            }
            else
            {
                throw new SpeedInvalidException("Error: Invalid Speed");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CarSpeed sp = new CarSpeed();  

            CarSpeedImplementation csp = new CarSpeedImplementation();

            try
            {
                csp.SetCarSpeed(sp, 90);
            }
            catch (SpeedInvalidException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
