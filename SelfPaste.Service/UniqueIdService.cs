using System;
using System.Collections.Generic;
using System.Text;

namespace SelfPaste.Service
{
    public class UniqueIdService
    {
        private long _lastTimestamp = GetCurrentUnixTimestamp();
        private long _lastGenerated = 0;

        public string GenerateUniqueId()
        {
            long currentTimestamp = GetCurrentUnixTimestamp();

            if (currentTimestamp != _lastTimestamp)
            {
                _lastTimestamp = currentTimestamp;
                _lastGenerated = 0;
            }

            if (_lastGenerated == 99_999)
            {
                throw new Exception("Cannot generate more than 100,000 unique ids per 100ms.");
            }

            long id = _lastTimestamp * 100_000 + (++_lastGenerated);

            return System.Convert.ToBase64String(BitConverter.GetBytes(id)).Replace('+', '-').Replace('/', '_');
        }

        private static long GetCurrentUnixTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 100;
        }
    }
}
