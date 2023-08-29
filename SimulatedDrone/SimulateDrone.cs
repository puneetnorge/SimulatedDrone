using System;

namespace SimulatedDrone
{
    class Drone
    {
        // x,y,z location of the drone
        private float x = 0.0F, y = 0.0F, z = 0.0F;

        // Signal to Noise ratio from RF signal
        private float SNR = 0.0F;

        // Method for reading the XYZ location of Drone
        public void Display_XYZ()
        {
            // 4 white spaces for representing each value
            Console.WriteLine("X = {0,4:N0}, Y = {1,4:N0}, Z = {2,4:N0}", x, y, z);

        }

        // Method for writing the XYZ location of Drone (useful for simulation)
        public void Write_XYZ(float x_1, float y_1, float z_1)
        {
            x = x_1;
            y = y_1;
            z = z_1;

        }

        public void Write_SNR(float snr_1)
        {
            SNR = snr_1;
        }

        // This method returns a double value
        public double Read_SNR()
        {
            return SNR;
        }

        // Note that this method does not return any value
        public void Return_home()
        {
            // Some procedure that returns the Drone to its home position

            Console.WriteLine(":::: Return Home Procedure Started ::::");
            // More statements follow here..

        }


        public void Normal_Operations()
        {           

            Console.WriteLine("*** --- Normal Operations  --- ***");
            // More statements follow here..

        }




    }

    // This Class is mainly used for generating testing data
    class SimulatedValuesAndConditions
    {
        Drone dr_obj = new Drone();
        public void SimulatedXYZ()
        {
            Random rand = new Random();
            for(int i=0; i<20;i++)
            {
                // Here X and Y values can vary more
                float x_val = (float) rand.Next(25, 50);
                float y_val = (float) rand.Next(50, 101);
                /* Here Z indicates the height (lets assume that it flies
                 * in a range [0,10] meters)*/
                float z_val = (float) rand.Next(0, 10);
                float snr_val = (float) rand.NextDouble()*100;

                dr_obj.Write_XYZ(x_val, y_val, z_val);
                dr_obj.Write_SNR(snr_val);
                dr_obj.Display_XYZ();
                double snr_2 = dr_obj.Read_SNR();
                Console.WriteLine("SNR = {0}", snr_2);


                // To caluclate euclidean distance we need to bring an object of type Math operations here

                MathOperations mat_obj = new MathOperations();

                float distance = mat_obj.Eulidean_Distance(x_val, y_val, z_val, 0.0F, 0.0F, 0.0F);
                Console.WriteLine("Euclidean distance based on Origin (0,0,0) is = {0}", distance);

                // If SNR is less than 50 or Z coordinate is greater than 5
                if (snr_2 < 50 || z_val > 5)
                {
                    dr_obj.Return_home();
                }
                else
                {
                    dr_obj.Normal_Operations();
                }
            }
        }
    }


    // A Class to perform some basic math operations on the data

    class MathOperations
    {
        // For now it has only one method but can be extended later on

        // Eulidean_Distance returns distance between two 3D points
        public float Eulidean_Distance(float x_1, float y_1, float z_1, float x_2, float y_2, float z_2)
        { 
            float diff_X = x_2 - x_1;
            float diff_Y = y_2 - y_1;
            float diff_Z = z_2 - z_1;
            // Sqrt from Math library
            float distance = (float)Math.Sqrt(diff_X * diff_X + diff_Y * diff_Y + diff_Z * diff_Z);
            return distance;
        }
    }
    
    // Class with Main method
    class SimulateDrone
    {
        static void Main(string[] args)
        {
            SimulatedValuesAndConditions sim_obj = new SimulatedValuesAndConditions();
            sim_obj.SimulatedXYZ();
            Console.ReadKey();
        }
    }
}
