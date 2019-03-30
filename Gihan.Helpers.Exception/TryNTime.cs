using System;

namespace Gihan.Helpers.Exception
{
    public class TryNTimes
    {
        public byte TryTimes { get; }
        public TryNTimes(byte tryTimes)
        {
            TryTimes = tryTimes;
        }
        public bool TryCatch<T>(Action Try, Action<T> Catch) where T : Exception
            => TryCatch(Try, null, Catch);
        public bool TryCatch<T>(Action Try, Action<T, byte> eachTimeCatch, Action<T> endCatch) where T : Exception
            => TryCatchNTimes(Try, eachTimeCatch, endCatch, TryTimes);

        public static bool TryCatchNTimes<T>(Action Try, Action<T> Catch, byte tryTimes) where T : Exception
            => TryCatchNTimes(Try, null, Catch, tryTimes);
        public static bool TryCatchNTimes<T>(Action Try, Action<T, byte> eachTimeCatch, Action<T> endCatch, byte tryTimes)
            where T : Exception
        {
            var triedTime = byte.MaxValue;
            while (true)
            {
                try
                {
                    triedTime++;
                    Try.Invoke();
                    break;
                }
                catch (T err)
                {
                    eachTimeCatch?.Invoke(err, triedTime);
                    if (triedTime < tryTimes) continue;
                    endCatch?.Invoke(err);
                    return false;
                }
            }
            return true;
        }
    }
}
