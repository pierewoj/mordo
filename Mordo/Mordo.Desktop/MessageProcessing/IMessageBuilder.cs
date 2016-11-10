namespace Mordo.Desktop.MessageProcessing
{
    internal interface IMessageBuilder
    {
        string StartAuto();
        string StopAuto();
        string Reset();
        string Manual();
        string OpenFrame();
        string CloseFrame();
        string ManualStop();
        string ManualForward();
        string ManualBackward();
        string ManualRight();
        string ManualLeft();
        string DrivePidForward(int value);
        string DrivePidBackward(int value);
        string DriveConsantWheelVelocity(int left, int right);
        string SideKtir();
        string Pwm(decimal left, decimal right);
        string StopFast();
        string StopSlow();
        string GetSettings();
        string SetSettings();
    }
}