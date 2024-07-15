using RomanDoliba.Core;

public static class TimerExtensions 
{
   public static float OneStarResult(this TimerController timerController)
   {
        return timerController._timeOnStarsResult.OneStarResult;
   }
   public static float TwoStarResult(this TimerController timerController)
   {
        return timerController._timeOnStarsResult.TwoStarResult;
   }
   public static float ThreeStarResult(this TimerController timerController)
   {
        return timerController._timeOnStarsResult.ThreeStarResult;
   }
}
