using System.Device.Gpio;

namespace RS.PiLight
{
    public enum PinMode
    {
        Input,
        Output
    }

    public enum PinValue
    {
        Low,
        High
    }

    public class GpioHelper
    {
        private readonly GpioController gpio;

        public GpioHelper()
        {
            this.gpio = new GpioController();
        }
        
        public void SetPinMode(int pinId, PinMode mode)
        {
            gpio.OpenPin(pinId, (System.Device.Gpio.PinMode)mode);
        }

        public void WritePin(int pinId, PinValue val)
        {
            if(val == PinValue.Low)
            {
                gpio.Write(pinId, System.Device.Gpio.PinValue.Low);
            }
            else
            {
                gpio.Write(pinId, System.Device.Gpio.PinValue.High);
            }
        }
    }
}