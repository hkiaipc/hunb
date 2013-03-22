using System;
using System.Collections.Generic;
using System.Text;

namespace DTC
{
    /// <summary>
    /// 
    /// </summary>
    public class T
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout"></param>
        public T(TimeSpan timeout)
        {
            this.TimeOut = timeout;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Last
        {
            get { return _last; }
            set { _last = value; }
        } private DateTime _last;

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan TimeOut
        {
            get { return _timeOut; }
            set
            {
                if (value < TimeSpan.FromSeconds(1))
                    throw new ArgumentOutOfRangeException("TimeOut", value, "must >= 1s");
                _timeOut = value;
            }
        } private TimeSpan _timeOut = TimeSpan.FromSeconds(10);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsTimeOut()
        {
            return IsTimeOut(DateTime.Now);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTimeOut(DateTime dt)
        {
            TimeSpan ts = dt - this.Last;
            if (ts >= TimeOut || ts < TimeSpan.Zero)
                return true;
            else
                return false;
        }
    }
}