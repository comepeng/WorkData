using System.Threading;

namespace Compeng.Rpc.Core.Util
{
    /// <summary>
    /// 并发安全
    /// </summary>
    public class AtomicInteger
    {
        private int _value;

        public int Value
        {
            get => _value;
            set => Interlocked.Exchange(ref _value, value);
        }

        public AtomicInteger()
            : this(0)
        {
        }

        public AtomicInteger(int defaultValue)
        {
            _value = defaultValue;
        }

        /// <summary>
        /// 等价于i++
        /// </summary>
        /// <returns></returns>
        public int GetAndIncrement()
        {
            var current = Value;
            Interlocked.Increment(ref _value);
            return current;
        }

        /// <summary>
        /// 等价于++i
        /// </summary>
        /// <returns></returns>
        public int Increment()
        {
            Interlocked.Increment(ref _value);
            return _value;
        }

        /// <summary>
        /// 等价于--i
        /// </summary>
        /// <returns></returns>
        public int Decrement()
        {
            Interlocked.Decrement(ref _value);
            return _value;
        }

        public int Add(int value)
        {
            AddInternal(value);
            return _value;
        }

        private void AddInternal(int value)
        {
            Interlocked.Add(ref _value, value);
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case AtomicInteger atomicInteger:
                    return atomicInteger._value == _value;
                case int value:
                    return value == _value;
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #region 运算符重载

        public static AtomicInteger operator +(AtomicInteger atomicInteger, int value)
        {
            atomicInteger.AddInternal(value);
            return atomicInteger;
        }

        public static AtomicInteger operator +(int value, AtomicInteger atomicInteger)
        {
            atomicInteger.AddInternal(value);
            return atomicInteger;
        }

        public static AtomicInteger operator -(AtomicInteger atomicInteger, int value)
        {
            atomicInteger.AddInternal(-value);
            return atomicInteger;
        }

        public static AtomicInteger operator -(int value, AtomicInteger atomicInteger)
        {
            atomicInteger.AddInternal(-value);
            return atomicInteger;
        }

        public static implicit operator AtomicInteger(int value)
        {
            return new AtomicInteger(value);
        }

        public static implicit operator int(AtomicInteger atomicInteger)
        {
            return atomicInteger._value;
        }

        public static bool operator ==(AtomicInteger atomicInteger, int value)
        {
            return atomicInteger?._value == value;
        }

        public static bool operator !=(AtomicInteger atomicInteger, int value)
        {
            return !(atomicInteger == value);
        }

        public static bool operator ==(int value, AtomicInteger atomicInteger)
        {
            return atomicInteger?._value == value;
        }

        public static bool operator !=(int value, AtomicInteger atomicInteger)
        {
            return !(value == atomicInteger);
        }

        #endregion
    }
}