using System;
using System.Runtime.CompilerServices;
using BookCollection.Core;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace BookCollection.Service.Utilities
{
    public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : User
    {
        private readonly int _iterCount;
        private readonly int _saltSize;
        private readonly int _bytesRequested;
        private readonly byte[] _salt;

        public PasswordHasher()
        {
            _iterCount = 4;
            _saltSize = 16;
            _bytesRequested = 32;
            _salt = new byte[] { 0x32, 0x1E, 0x2F, 0x16, 0x44, 0x16, 0x02, 0xF5, 0x81, 0x7A, 0x5D, 0x0D, 0x01, 0x4B, 0xBB, 0x54 };
        }

        public string HashPassword(TUser user, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            return Convert.ToBase64String(HashPassword(password));
        }

        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }
            if (providedPassword == null)
            {
                throw new ArgumentNullException(nameof(providedPassword));
            }

            byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            if (decodedHashedPassword.Length == 0)
            {
                return PasswordVerificationResult.Failed;
            }
            switch (decodedHashedPassword[0])
            {
                case 0x01:
                    if (VerifyHashedPassword(decodedHashedPassword, providedPassword, out var embeddedIterCount))
                    {
                        return (embeddedIterCount < _iterCount)
                            ? PasswordVerificationResult.SuccessRehashNeeded
                            : PasswordVerificationResult.Success;
                    }
                    else
                    {
                        return PasswordVerificationResult.Failed;
                    }

                default:
                    return PasswordVerificationResult.Failed;
            }
        }

        private byte[] HashPassword(string password)
        {
            return HashPassword(password, prf: KeyDerivationPrf.HMACSHA256,
                iterCount: _iterCount,
                saltSize: _saltSize,
                salt: _salt,
                numBytesRequested: _bytesRequested);
        }

        private static byte[] HashPassword(string password, KeyDerivationPrf prf, int iterCount, int saltSize, byte[] salt, int numBytesRequested)
        {
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01;
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return outputBytes;
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                   | ((uint)(buffer[offset + 1]) << 16)
                   | ((uint)(buffer[offset + 2]) << 8)
                   | ((uint)(buffer[offset + 3]));
        }

        private static bool VerifyHashedPassword(byte[] hashedPassword, string password, out int iterCount)
        {
            iterCount = default(int);

            try
            {
                KeyDerivationPrf prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
                iterCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
                int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);
                
                if (saltLength < 128 / 8)
                {
                    return false;
                }
                byte[] salt = new byte[saltLength];
                Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);
                
                int subkeyLength = hashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                {
                    return false;
                }
                byte[] expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);
                
                byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);
                return ByteArraysEqual(actualSubkey, expectedSubkey);
            }
            catch
            {
                return false;
            }
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }
            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }
    }
}