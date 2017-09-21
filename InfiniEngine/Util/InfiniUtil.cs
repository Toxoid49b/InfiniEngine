using System;
using System.Security.Cryptography;

namespace InfiniEngine.Util {

    public class InfiniUtil {

        private static RNGCryptoServiceProvider randObj = new RNGCryptoServiceProvider();

        public struct RandomPool {

            public int[] validRange;
            public int maxValue;

            public RandomPool(int randomRange) {

                maxValue = randomRange;
                validRange = new int[randomRange];
                for (int I = 0; I < randomRange; I++) {
                    validRange[I] = I;
                }

            }

            public void ResetPool() {

                validRange = new int[maxValue];
                for (int I = 0; I < maxValue; I++) {
                    validRange[I] = I;
                }

            }

            public int GetNextRandom() {

                int nextValue = GetNextInt32(validRange.Length);
                int newValue = validRange[nextValue];

                if (validRange.Length - 1 > 0) {

                    int[] newPool = new int[validRange.Length - 1];
                    int decVal = 0;

                    for (int I = 0; I < validRange.Length; I++) {

                        if (I != nextValue) {

                            newPool[I - decVal] = validRange[I];

                        } else decVal++;

                    }

                    validRange = newPool;

                } else {

                    ResetPool();

                }

                return newValue;

            }

        }

        public static int GetNextInt32(int maxValue) {

            var buffer = new byte[4];
            int bits, val;

            if ((maxValue & -maxValue) == maxValue) {

                randObj.GetBytes(buffer);
                bits = BitConverter.ToInt32(buffer, 0);
                return bits & (maxValue - 1);

            }

            do {
                randObj.GetBytes(buffer);
                bits = BitConverter.ToInt32(buffer, 0) & 0x7FFFFFFF;
                val = bits % maxValue;
            } while (bits - val + (maxValue - 1) < 0);

            return val;

        }

        public static float GetNextFloat() {

            var buffer = new byte[4];
            randObj.GetBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);

        }

    }

}
