using System;
using System.Reflection;

namespace Framework.Core
{
    public class HashCodeBuilder
    {
        private readonly int _iConstant;

        private int _iTotal;

        public HashCodeBuilder()
        {
            _iConstant = 37;
            _iTotal = 17;
        }

        public HashCodeBuilder(int initialNonZeroOddNumber, int multiplierNonZeroOddNumber)
        {
            if (initialNonZeroOddNumber == 0)
            {
                throw new ArgumentException("HashCodeBuilder requires a non zero initial value");
            }
            if (initialNonZeroOddNumber % 2 == 0)
            {
                throw new ArgumentException("HashCodeBuilder requires an odd initial value");
            }
            if (multiplierNonZeroOddNumber == 0)
            {
                throw new ArgumentException("HashCodeBuilder requires a non zero multiplier");
            }
            if (multiplierNonZeroOddNumber % 2 == 0)
            {
                throw new ArgumentException("HashCodeBuilder requires an odd multiplier");
            }
            _iConstant = multiplierNonZeroOddNumber;
            _iTotal = initialNonZeroOddNumber;
        }

        public static int ReflectionHashCode(object obj)
        {
            return ReflectionHashCode(17, 37, obj, false, null);
        }


        public static int ReflectionHashCode(object obj, bool testTransients)
        {
            return ReflectionHashCode(17, 37, obj, testTransients, null);
        }


        public static int ReflectionHashCode(
            int initialNonZeroOddNumber, int multiplierNonZeroOddNumber, object obj)
        {
            return ReflectionHashCode(initialNonZeroOddNumber, multiplierNonZeroOddNumber, obj, false, null);
        }


        public static int ReflectionHashCode(
            int initialNonZeroOddNumber, int multiplierNonZeroOddNumber,
            object obj, bool testTransients)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return ReflectionHashCode(initialNonZeroOddNumber, multiplierNonZeroOddNumber, obj, testTransients, null);
        }


        public static int ReflectionHashCode(
            int initialNonZeroOddNumber,
            int multiplierNonZeroOddNumber,
            object obj,
            bool testTransients,
            Type reflectUpToClass)
        {
            if (obj == null)
            {
                throw new ArgumentException("The object to build a hash code for must not be null");
            }
            var builder = new HashCodeBuilder(initialNonZeroOddNumber, multiplierNonZeroOddNumber);
            var clazz = obj.GetType();
            ReflectionAppend(obj, clazz, builder, testTransients);
            while (clazz.BaseType != null && clazz != reflectUpToClass)
            {
                clazz = clazz.BaseType;
                ReflectionAppend(obj, clazz, builder, testTransients);
            }
            return builder.ToHashCode();
        }


        private static void ReflectionAppend(object obj, IReflect clazz, HashCodeBuilder builder, bool useTransients)
        {
            var fields =
                clazz.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                                | BindingFlags.GetField);
            foreach (var f in fields)
            {
                if ((f.Name.IndexOf('$') != -1) || (!useTransients && IsTransient(f)) || f.IsStatic) continue;
                try
                {
                    builder.Append(f.GetValue(obj));
                }
                catch (Exception)
                {
                    throw new Exception("Unexpected IllegalAccessException");
                }
            }
        }


        public HashCodeBuilder AppendSuper(int superHashCode)
        {
            _iTotal = _iTotal * _iConstant + superHashCode;
            return this;
        }


        public HashCodeBuilder Append(object obj)
        {
            if (obj == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                if (obj.GetType().IsArray == false)
                {
                    _iTotal = _iTotal * _iConstant + obj.GetHashCode();
                }
                else
                {
                    if (obj is long[] longs)
                    {
                        Append(longs);
                    }
                    else if (obj is int[])
                    {
                        Append((int[])obj);
                    }
                    else if (obj is short[])
                    {
                        Append((short[])obj);
                    }
                    else if (obj is char[])
                    {
                        Append((char[])obj);
                    }
                    else if (obj is byte[])
                    {
                        Append((byte[])obj);
                    }
                    else if (obj is double[])
                    {
                        Append((double[])obj);
                    }
                    else if (obj is float[])
                    {
                        Append((float[])obj);
                    }
                    else if (obj is bool[])
                    {
                        Append((bool[])obj);
                    }
                    else
                    {
                        Append((object[])obj);
                    }
                }
            }
            return this;
        }

        public HashCodeBuilder Append(long value)
        {
            _iTotal = _iTotal * _iConstant + ((int)(value ^ (value >> 32)));
            return this;
        }

        public HashCodeBuilder Append(int value)
        {
            _iTotal = _iTotal * _iConstant + value;
            return this;
        }

        public HashCodeBuilder Append(short value)
        {
            _iTotal = _iTotal * _iConstant + value;
            return this;
        }

        public HashCodeBuilder Append(char value)
        {
            _iTotal = _iTotal * _iConstant + value;
            return this;
        }

        public HashCodeBuilder Append(byte value)
        {
            _iTotal = _iTotal * _iConstant + value;
            return this;
        }

        public HashCodeBuilder Append(double value)
        {
            return Append(Convert.ToInt64(value));
        }

        public HashCodeBuilder Append(float value)
        {
            _iTotal = _iTotal * _iConstant + Convert.ToInt32(value);
            return this;
        }

        public HashCodeBuilder Append(bool value)
        {
            _iTotal = _iTotal * _iConstant + (value ? 0 : 1);
            return this;
        }

        public HashCodeBuilder Append(object[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(long[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(int[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(short[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(char[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(byte[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(double[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }


        public HashCodeBuilder Append(float[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public HashCodeBuilder Append(bool[] array)
        {
            if (array == null)
            {
                _iTotal = _iTotal * _iConstant;
            }
            else
            {
                foreach (var t in array)
                {
                    Append(t);
                }
            }
            return this;
        }

        public int ToHashCode()
        {
            return _iTotal;
        }

        private static bool IsTransient(FieldInfo fieldInfo)
        {
            return (fieldInfo.Attributes & FieldAttributes.NotSerialized) == FieldAttributes.NotSerialized;
        }
    }
}