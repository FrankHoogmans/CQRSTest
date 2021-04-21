using System;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace CQRSTest.AutoMapper
{
    /// <summary>
    /// Provides a way to decrypt values
    /// </summary>
    public class SecureValueConverter : IValueConverter<string, string>
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public SecureValueConverter(IDataProtectionProvider dataProtectionProvider)
        {
            this._dataProtectionProvider = dataProtectionProvider;
        }

        public string Convert(string sourceMember, ResolutionContext context)
        {
            try
            {
                return _dataProtectionProvider.CreateProtector("Secure").Unprotect(sourceMember);
            }
            catch (Exception ex)
            {
                return sourceMember;
            }
        }
    }
}
